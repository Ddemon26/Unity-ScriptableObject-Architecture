using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a float variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/FloatVariable")]
    public class FloatVariable : MinMaxValueAsset<float>
    {
        public void ApplyChange(float amount)
        {
            SetValue(value += amount);
        }
        public void ApplyChange(FloatVariable amount)
        {
            SetValue(value += amount.Value);
        }
        public void SetValueFromString(string assetValue)
        {
            SetValue(float.Parse(assetValue));
        }
    }
}
