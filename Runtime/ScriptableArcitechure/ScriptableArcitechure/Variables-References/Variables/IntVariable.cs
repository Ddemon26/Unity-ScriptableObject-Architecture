using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/IntVariable")]
    public class IntVariable : MinMaxValueAsset<int>
    {
        public void ApplyChange(int amount)
        {
            SetValue(Value += amount);
        }
        public void ApplyChange(ValueAsset<float> amount)
        {
            SetValue(Value += (int)amount.Value);
        }
        public void SetValueFromString(string refValue)
        {
            SetValue(int.Parse(refValue));
        }
    }
}