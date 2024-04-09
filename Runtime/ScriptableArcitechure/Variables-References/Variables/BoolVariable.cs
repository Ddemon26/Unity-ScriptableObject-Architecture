using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a boolean variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/BoolVariable")]
    public class BoolVariable : ValueAsset<bool>
    {
        public void SetTrue()
        {
            SetValue(true);
        }
        public void SetFalse()
        {
            SetValue(false);
        }
        public void Toggle()
        {
            Value = !Value;
        }
    }
}