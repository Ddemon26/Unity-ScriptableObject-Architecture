using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Vector4 variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/Vector4Variable")]
    public class Vector4Variable : ValueAsset<Vector4>
    {
        /// <summary>
        /// Applies a change to the value of the Vector4 variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Vector4 amount)
        {
            SetValue(value += amount);
        }

        /// <summary>
        /// Applies a change to the value of the Vector4 variable from another Vector4Variable.
        /// </summary>
        /// <param name="amount">The Vector4Variable to get the change amount from.</param>
        public void ApplyChange(Vector4Variable amount)
        {
            SetValue(value += amount.value);
        }
    }
}