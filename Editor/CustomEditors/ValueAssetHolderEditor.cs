using System;
using System.Collections.Generic;
using System.Reflection;
using ScriptableArchitect.Variables;
using UnityEditor;
using UnityEngine;
using System.Linq;
using static ScriptableArchitect.Editor.EditorUtil;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Editor
{
    [CustomEditor(typeof(ValueAssetHolder), true)]
    public class ValueAssetHolderEditor : UnityEditor.Editor
    {
        private readonly Dictionary<int, ToolBeltGroup> groups = new Dictionary<int, ToolBeltGroup>();
        [SerializeField] private string assetPath;

        private void OnEnable()
        {
            assetPath = EditorPrefs.GetString("AssetPath", "Assets/");
            InitializeGroups();
        }

        private void InitializeGroups()
        {
            groups.Clear();
            var fields = target.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            ToolBeltGroup currentGroup = null;

            foreach (var field in fields)
            {
                ProcessField(field, ref currentGroup);
            }
        }

        private void ProcessField(MemberInfo field, ref ToolBeltGroup currentGroup)
        {
            var attribute = field.GetCustomAttribute<ToolBeltAttribute>();
            if (attribute != null)
            {
                currentGroup = new ToolBeltGroup(attribute.GroupId);
                groups[attribute.GroupId] = currentGroup;
            }

            currentGroup?.FieldNames.Add(field.Name);
        }

        public override void OnInspectorGUI()
        {
            DrawScriptProperty();
            SelectAssetPathGUI();
            DrawGroupButtons();
            DrawProperties();
            EditorGUILayout.Space(); // Add a space
            EditorGUILayout.LabelField("Create Assets", EditorStyles.boldLabel); // Add a header
            DrawVariableCreationButtons();
            FinalizeInspectorGUI();
        }

        private void DrawScriptProperty()
        {
            var scriptProperty = serializedObject.FindProperty("m_Script");
            GUI.enabled = false;
            EditorGUILayout.PropertyField(scriptProperty, true, Array.Empty<GUILayoutOption>());
            GUI.enabled = true;
        }

        private void SelectAssetPathGUI()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Select Asset Path"))
            {
                SelectAssetPath();
            }

            assetPath = EditorGUILayout.TextField(assetPath);
            EditorGUILayout.EndHorizontal();
        }

        private void SelectAssetPath()
        {
            var selectedPath = EditorUtility.OpenFolderPanel("Select Asset Path", assetPath, "");
            if (string.IsNullOrEmpty(selectedPath)) return;

            var projectPath = System.IO.Path.GetFullPath(Application.dataPath + "/../");
            assetPath = System.IO.Path.GetRelativePath(projectPath, selectedPath) + "/";
        }

        private void DrawGroupButtons()
        {
            var buttonCount = 0;
            GUILayout.BeginHorizontal();
            foreach (var group in groups.Values)
            {
                DrawGroupButton(group, ref buttonCount);
            }

            GUILayout.EndHorizontal();
        }

        private void DrawProperties()
        {
            GUI.backgroundColor = Color.white; // Reset color
            DrawPropertiesExcluding(serializedObject,
                groups.SelectMany(g => g.Value.FieldNames).Append("m_Script").ToArray());

            foreach (var group in groups.Values)
            {
                if (!group.IsVisible) continue;

                var index = 0;

                for (; index < group.FieldNames.Count; index++)
                {
                    var fieldName = group.FieldNames[index];
                    var field = serializedObject.FindProperty(fieldName);
                    EditorGUILayout.PropertyField(field, true);
                }
            }
        }

        private void DrawVariableCreationButtons()
        {
            var holder = (ValueAssetHolder)target;
            var options = new Dictionary<string, Action>
            {
                { "Int Variable", () => CreateNewVariable<IntVariable>(holder) },
                { "Float Variable", () => CreateNewVariable<FloatVariable>(holder) },
                { "Bool Variable", () => CreateNewVariable<BoolVariable>(holder) },
                { "String Variable", () => CreateNewVariable<StringVariable>(holder) },
                { "Vector2 Variable", () => CreateNewVariable<Vector2Variable>(holder) },
                { "Vector3 Variable", () => CreateNewVariable<Vector3Variable>(holder) },
                { "Vector4 Variable", () => CreateNewVariable<Vector4Variable>(holder) },
                { "Color Variable", () => CreateNewVariable<ColorVariable>(holder) },
                { "Sprite Variable", () => CreateNewVariable<SpriteVariable>(holder) },
                { "Material Variable", () => CreateNewVariable<MaterialVariable>(holder) },
                { "Texture Variable", () => CreateNewVariable<TextureVariable>(holder) },
                { "Audio Clip Variable", () => CreateNewVariable<AudioClipVariable>(holder) },
                { "Animation Clip Variable", () => CreateNewVariable<AnimationClipVariable>(holder) },
                { "Animation Curve Variable", () => CreateNewVariable<AnimationCurveVariable>(holder) },
                { "Animation Controller Variable", () => CreateNewVariable<AnimationControllerVariable>(holder) },
            };

            GUILayout.BeginVertical();
            var i = 0;
            foreach (var option in options)
            {
                if (i % 3 == 0)
                {
                    GUILayout.BeginHorizontal();
                }

                if (GUILayout.Button(option.Key))
                {
                    option.Value.Invoke();
                }

                if (i % 3 == 2 || i == options.Count - 1)
                {
                    GUILayout.EndHorizontal();
                }

                i++;
            }

            GUILayout.EndVertical();
        }

        private void FinalizeInspectorGUI()
        {
            Repaint();
            serializedObject.ApplyModifiedProperties();
        }

        private void CreateNewVariable<T>(ValueAssetHolder holder) where T : ScriptableObject, new()
        {
            var newVariable = CreateInstance<T>();
            var assetName = GenerateUniqueAssetName<T>();
            AddVariableToHolder(newVariable, holder);
            SaveVariableAsAsset(newVariable, assetName);
            MarkHolderAsDirty(holder);
        }

        private string GenerateUniqueAssetName<T>() where T : new()
        {
            var count = 1;
            var assetName = $"{typeof(T).Name}_{count:D2}";
            while (AssetDatabase.LoadAssetAtPath($"{assetPath}/{assetName}.asset", typeof(T)) != null)
            {
                count++;
                assetName = $"{typeof(T).Name}_{count:D2}";
            }

            return assetName;
        }

        private static void AddVariableToHolder<T>(T variable, ValueAssetHolder holder) where T : ScriptableObject
        {
            var typeToListMap = new Dictionary<Type, object>
            {
                { typeof(IntVariable), holder.intVariable },
                { typeof(FloatVariable), holder.floatVariable },
                { typeof(BoolVariable), holder.boolVariable },
                { typeof(StringVariable), holder.stringVariable },
                { typeof(Vector2Variable), holder.vector2Variable },
                { typeof(Vector3Variable), holder.vector3Variable },
                { typeof(Vector4Variable), holder.vector4Variable },
                { typeof(ColorVariable), holder.colorVariable },
                { typeof(SpriteVariable), holder.spriteVariable },
                { typeof(MaterialVariable), holder.materialVariable },
                { typeof(TextureVariable), holder.textureVariables },
                { typeof(AudioClipVariable), holder.audioClipVariable },
                { typeof(AnimationClipVariable), holder.animationVariable },
                { typeof(AnimationCurveVariable), holder.animationCurveVariable },
                { typeof(AnimationControllerVariable), holder.animationControllerVariable },
            };

            if (typeToListMap.TryGetValue(typeof(T), out var list))
            {
                (list as List<T>)?.Add(variable);
            }
            else
            {
                throw new InvalidOperationException($"Unsupported variable type: {typeof(T)}");
            }
        }


        private void SaveVariableAsAsset<T>(T variable, string assetName) where T : ScriptableObject
        {
            var fullPath = $"{assetPath}{assetName}.asset";
            AssetDatabase.CreateAsset(variable, fullPath);
            AssetDatabase.SaveAssets();
        }
    }
}