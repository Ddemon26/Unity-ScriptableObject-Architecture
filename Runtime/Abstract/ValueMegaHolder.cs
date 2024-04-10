using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A ScriptableObject for holding various typed variables.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/TestHolder")]
    public class ValueMegaHolder : ScriptableObject
    {
        public List<IntVariable> intVariable = new List<IntVariable>();
        public List<FloatVariable> floatVariable = new List<FloatVariable>(); 
        public List<BoolVariable> boolVariable = new List<BoolVariable>();
        public List<StringVariable> stringVariable = new List<StringVariable>();
        public List<Vector2Variable> vector2Variable = new List<Vector2Variable>(); 
        public List<Vector3Variable> vector3Variable = new List<Vector3Variable>();
        public List<Vector4Variable> vectorVariable = new List<Vector4Variable>();
        public List<ColorVariable> colorVariable = new List<ColorVariable>(); 
        public List<ColorArrayVariable> colorArray = new List<ColorArrayVariable>(); 
        public List<SpriteVariable> spriteVariable = new List<SpriteVariable>();
        public List<QuaternionVariable> quaternionVariable = new List<QuaternionVariable>();

        public List<AnimationCurveVariable>
            animationCurveVariable = new List<AnimationCurveVariable>(); 

        public List<AnimationVariable> animationVariable = new List<AnimationVariable>(); 
        public List<AnimatorVariable> animatorVariable = new List<AnimatorVariable>();
        public List<AudioClipVariable> audioClipVariable = new List<AudioClipVariable>(); 

        public List<AudioClipArrayVariable>
            audioClipArrayVariable = new List<AudioClipArrayVariable>();

        public List<LayerMaskVariable> layerMaskVariable = new List<LayerMaskVariable>(); 
        public List<MaterialArrayVariable> materialArrayVariable = new List<MaterialArrayVariable>(); // Corrected plural form
        public List<MaterialVariable> materialVariable = new List<MaterialVariable>(); // Corrected plural form
        public List<PrefabVariable> prefabVariable = new List<PrefabVariable>(); // Corrected plural form
        public List<PrefabArrayVariable> prefabArrayVariable = new List<PrefabArrayVariable>(); // Corrected plural form
        public List<RectVariable> rectVariable = new List<RectVariable>(); // Kept as is, already plural

        public List<ScriptableObjectVariable>
            scriptableObjectVariable = new List<ScriptableObjectVariable>();

        public List<TextureVariable> textureVariables = new List<TextureVariable>(); 

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