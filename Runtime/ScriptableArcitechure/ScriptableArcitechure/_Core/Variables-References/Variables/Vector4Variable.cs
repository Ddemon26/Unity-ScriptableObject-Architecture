using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Vector4 variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/Vector4Variable")]
    public class Vector4Variable : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The value of the Vector4 variable.
        /// </summary>
        public Vector4 Value;

        /// <summary>
        /// Sets the value of the Vector4 variable from a Vector4.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Vector4 value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Vector4 variable from another Vector4Variable.
        /// </summary>
        /// <param name="value">The Vector4Variable to get the new value from.</param>
        public void SetValue(Vector4Variable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Applies a change to the value of the Vector4 variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Vector4 amount)
        {
            Value += amount;
        }

        /// <summary>
        /// Applies a change to the value of the Vector4 variable from another Vector4Variable.
        /// </summary>
        /// <param name="amount">The Vector4Variable to get the change amount from.</param>
        public void ApplyChange(Vector4Variable amount)
        {
            Value += amount.Value;
        }
    }
}