using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Vector2 variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Variables/Vector2Variable")]
    public class Vector2Variable : ScriptableObject
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
        /// The value of the Vector2 variable.
        /// </summary>
        public Vector2 Value;
        /// <summary>
        /// Sets the value of the Vector2 variable from a Vector2.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Vector2 value)
        {
            Value = value;
        }
        /// <summary>
        /// Sets the value of the Vector2 variable from another Vector2Variable.
        /// </summary>
        /// <param name="value">The Vector2Variable to get the new value from.</param>
        public void SetValue(Vector2Variable value)
        {
            Value = value.Value;
        }
        /// <summary>
        /// Applies a change to the value of the Vector2 variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Vector2 amount)
        {
            Value += amount;
        }
        /// <summary>
        /// Applies a change to the value of the Vector2 variable from another Vector2Variable.
        /// </summary>
        /// <param name="amount">The Vector2Variable to get the change amount from.</param>
        public void ApplyChange(Vector2Variable amount)
        {
            Value += amount.Value;
        }
    }
}