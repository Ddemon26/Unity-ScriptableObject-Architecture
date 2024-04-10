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
        [SerializeField]
        public List<IntVariable> intVariable = new List<IntVariable>();
        [SerializeField]
        public List<FloatVariable> floatVariable = new List<FloatVariable>();
        [SerializeField]
        public List<BoolVariable> boolVariable = new List<BoolVariable>();
        [SerializeField]
        public List<StringVariable> stringVariable = new List<StringVariable>();
        [SerializeField]
        public List<AnimationCurveVariable> animationCurveVariable = new List<AnimationCurveVariable>();

        [Header("Vector Types")]
        [ToolBelt("Vector Types", 2)]
        [SerializeField]
        public List<Vector2Variable> vector2Variable = new List<Vector2Variable>();
        [SerializeField]
        public List<Vector3Variable> vector3Variable = new List<Vector3Variable>();
        [SerializeField]
        public List<Vector4Variable> vector4Variable = new List<Vector4Variable>();

        [Header("Graphics")]
        [ToolBelt("Graphics", 3)]
        [SerializeField]
        public List<ColorVariable> colorVariable = new List<ColorVariable>();
        [SerializeField]
        public List<SpriteVariable> spriteVariable = new List<SpriteVariable>();
        [SerializeField]
        public List<MaterialVariable> materialVariable = new List<MaterialVariable>();
        [SerializeField]
        public List<TextureVariable> textureVariables = new List<TextureVariable>();
        
        [Header("Audio")]
        [ToolBelt("Audio", 4)]
        [SerializeField]
        public List<AudioClipVariable> audioClipVariable = new List<AudioClipVariable>();

        [Header("Game Objects & Components")] 
        [ToolBelt("Game Objects & Components", 5)]
        [SerializeField]
        public List<AnimationClipVariable> animationVariable = new List<AnimationClipVariable>();
        [SerializeField]
        public List<AnimationControllerVariable> animationControllerVariable = new List<AnimationControllerVariable>();

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