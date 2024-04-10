using System;
using System.Collections.Generic;
using System.Reflection;
using ScriptableArchitect.Variables;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace ScriptableArchitect.Editor
{
    [CustomEditor(typeof(ValueAssetHolder), true)]
    public class ToolBeltEditor : UnityEditor.Editor
    {
        private Dictionary<int, ToolBeltGroup> groups = new Dictionary<int, ToolBeltGroup>();
        [SerializeField]
        private string assetPath = "Assets/"; // Default path

        private void OnEnable()
        {
            // Initialize groups
            groups.Clear();
            var fields = target.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            ToolBeltGroup currentGroup = null;

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute<ToolBeltAttribute>();
                if (attribute != null)
                {
                    currentGroup = new ToolBeltGroup(attribute.GroupId);
                    groups[attribute.GroupId] = currentGroup;
                }

                if (currentGroup != null)
                {
                    currentGroup.FieldNames.Add(field.Name);
                }
            }
        }

        public override void OnInspectorGUI()
        {
            // Draw the script instance data
            SerializedProperty scriptProperty = serializedObject.FindProperty("m_Script");
            GUI.enabled = false; // Disable GUI to make the script field read-only
            EditorGUILayout.PropertyField(scriptProperty, true, new GUILayoutOption[0]);
            GUI.enabled = true; // Enable GUI for the rest of the inspector

            // Add a field for the developer to select the path to save the asset
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Select Asset Path"))
            {
                string selectedPath = EditorUtility.OpenFolderPanel("Select Asset Path", assetPath, "");
                if (!string.IsNullOrEmpty(selectedPath))
                {
                    // Convert absolute path to relative path
                    string projectPath = System.IO.Path.GetFullPath(Application.dataPath + "/../");
                    assetPath = System.IO.Path.GetRelativePath(projectPath, selectedPath) + "/";
                }
            }

            assetPath = EditorGUILayout.TextField(assetPath);
            EditorGUILayout.EndHorizontal(); // Ensure this call is made

            // Handle each group's button and visibility
            int buttonCount = 0;
            GUILayout.BeginHorizontal();
            foreach (var group in groups.Values)
            {
                if (buttonCount != 0 && buttonCount % 5 == 0)
                {
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }

                GUI.backgroundColor = group.IsVisible ? Color.green : Color.gray;
                if (GUILayout.Button(group.IsVisible ? $"Hide {group.GroupId}" : $"Show {group.GroupId}"))
                {
                    group.IsVisible = !group.IsVisible;
                }

                buttonCount++;
            }

            GUILayout.EndHorizontal(); // Ensure this call is made
            GUI.backgroundColor = Color.white; // Reset color

            // Draw properties not in any ToolBelt group, excluding the script field
            DrawPropertiesExcluding(serializedObject,
                groups.SelectMany(g => g.Value.FieldNames).Append("m_Script").ToArray());

            foreach (var group in groups.Values)
            {
                if (group.IsVisible)
                {
                    foreach (var fieldName in group.FieldNames)
                    {
                        var field = serializedObject.FindProperty(fieldName);
                        EditorGUILayout.PropertyField(field, true);
                    }
                }
            }

            ValueAssetHolder holder = (ValueAssetHolder)target;

            if (GUILayout.Button("Create New Int Variable"))
            {
                CreateNewVariable<IntVariable>(holder);
            }

            if (GUILayout.Button("Create New Float Variable"))
            {
                CreateNewVariable<FloatVariable>(holder);
            }

            // Force the inspector to repaint, ensuring the button is visible
            Repaint();

            serializedObject.ApplyModifiedProperties();
        }
        
        private void CreateNewVariable<T>(ValueAssetHolder holder) where T : ScriptableObject, new()
        {
            // Create a new variable of type T
            T newVariable = ScriptableObject.CreateInstance<T>();

            // Check if a variable with the same name already exists
            int count = 1;
            string assetName = $"{typeof(T).Name}_{count:D2}";
            while (AssetDatabase.LoadAssetAtPath($"{assetPath}/{assetName}.asset", typeof(T)) != null)
            {
                count++;
                assetName = $"{typeof(T).Name}_{count:D2}";
            }

            // Add the new variable to the proper list based on its type
            switch (newVariable)
            {
                case IntVariable variable:
                    holder.intVariable.Add(variable);
                    break;
                case FloatVariable variable:
                    holder.floatVariable.Add(variable);
                    break;
                // Add cases for other types as needed...
                default:
                    throw new InvalidOperationException($"Unsupported variable type: {typeof(T)}");
            }

            // Save the new variable as an asset in the project
            string fullPath = $"{assetPath}{assetName}.asset";
            AssetDatabase.CreateAsset(newVariable, fullPath);
            AssetDatabase.SaveAssets();

            // Mark the holder as dirty to force Unity to refresh the inspector
            EditorUtility.SetDirty(holder);
        }
    }
}