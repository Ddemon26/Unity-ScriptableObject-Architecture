using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A ScriptableObject for holding various typed variables.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/ValueAssetHolder", fileName = "ValueAssetHolder")]
    public class ValueAssetHolder : ScriptableObject
    {
        [Header("Primitive Types")] 
        [ToolBelt("Primitive Types", 1)]
        public List<IntVariable> intVariable = new List<IntVariable>();
        public List<FloatVariable> floatVariable = new List<FloatVariable>();
        public List<BoolVariable> boolVariable = new List<BoolVariable>();
        public List<StringVariable> stringVariable = new List<StringVariable>();

        [Header("Vector Types")]
        [ToolBelt("Vector Types", 2)]
        public List<Vector2Variable> vector2Variable = new List<Vector2Variable>();
        public List<Vector3Variable> vector3Variable = new List<Vector3Variable>();
        public List<Vector4Variable> vectorVariable = new List<Vector4Variable>();
        public List<QuaternionVariable> quaternionVariable = new List<QuaternionVariable>();

        [Header("Graphics")]
        [ToolBelt("Graphics", 3)]
        public List<ColorVariable> colorVariable = new List<ColorVariable>();
        public List<SpriteVariable> spriteVariable = new List<SpriteVariable>();
        public List<MaterialVariable> materialVariable = new List<MaterialVariable>();
        public List<TextureVariable> textureVariables = new List<TextureVariable>();
        
        [Header("Audio")]
        [ToolBelt("Audio", 4)]
        public List<AudioClipVariable> audioClipVariable = new List<AudioClipVariable>();

        [Header("Game Objects & Components")] 
        [ToolBelt("Game Objects & Components", 5)]
        public List<PrefabVariable> prefabVariable = new List<PrefabVariable>();
        public List<AnimationVariable> animationVariable = new List<AnimationVariable>();
        public List<AnimatorVariable> animatorVariable = new List<AnimatorVariable>();
        public List<AnimationCurveVariable> animationCurveVariable = new List<AnimationCurveVariable>();
        public List<LayerMaskVariable> layerMaskVariable = new List<LayerMaskVariable>();
        public List<RectVariable> rectVariable = new List<RectVariable>();
        public List<ScriptableObjectVariable> scriptableObjectVariable = new List<ScriptableObjectVariable>();


        public void AddVariable<T>(T variable) where T : ScriptableObject
        {
            (GetType().GetProperty(typeof(T).Name)?.GetValue(this) as List<T>)?.Add(variable);
        }

        public T GetValue<T>(List<ValueAsset<T>> valueAssetList, int index) where T : System.IComparable<T>
        {
            return valueAssetList[index].Value;
        }

        public void SetValue<T>(List<ValueAsset<T>> valueAssetList, int index, T value) where T : System.IComparable<T>
        {
            valueAssetList[index].Value = value;
        }
    }
}