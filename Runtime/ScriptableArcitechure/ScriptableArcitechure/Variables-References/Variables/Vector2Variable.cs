using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Vector2 variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/Vector2Variable")]
    public class Vector2Variable : ValueAsset<Vector2>
    {
        /// <summary>
        /// Applies a change to the value of the Vector2 variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Vector2 amount)
        {
            SetValue(value += amount);
        }
        /// <summary>
        /// Applies a change to the value of the Vector2 variable from another Vector2Variable.
        /// </summary>
        /// <param name="amount">The Vector2Variable to get the change amount from.</param>
        public void ApplyChange(Vector2Variable amount)
        {
            SetValue(value += amount.value);
        }
    }
}