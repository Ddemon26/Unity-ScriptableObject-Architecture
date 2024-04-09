using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Vector3 variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/Vector3Variable")]
    public class Vector3Variable : ValueAsset<Vector3>
    {
        /// <summary>
        /// Applies a change to the value of the Vector3 variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Vector3 amount)
        {
            SetValue(value += amount);
        }

        /// <summary>
        /// Applies a change to the value of the Vector3 variable from another Vector3Variable.
        /// </summary>
        /// <param name="amount">The Vector3Variable to get the change amount from.</param>
        public void ApplyChange(Vector3Variable amount)
        {
            SetValue(value += amount.value);
        }
    }
}