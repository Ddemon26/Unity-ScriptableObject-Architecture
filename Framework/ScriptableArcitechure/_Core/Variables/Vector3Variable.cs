using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Vector3 variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Variables/Vector3Variable")]
    public class Vector3Variable : ScriptableObject
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
        /// The value of the Vector3 variable.
        /// </summary>
        public Vector3 Value;

        /// <summary>
        /// Sets the value of the Vector3 variable from a Vector3.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Vector3 value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Vector3 variable from another Vector3Variable.
        /// </summary>
        /// <param name="value">The Vector3Variable to get the new value from.</param>
        public void SetValue(Vector3Variable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Applies a change to the value of the Vector3 variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Vector3 amount)
        {
            Value += amount;
        }

        /// <summary>
        /// Applies a change to the value of the Vector3 variable from another Vector3Variable.
        /// </summary>
        /// <param name="amount">The Vector3Variable to get the change amount from.</param>
        public void ApplyChange(Vector3Variable amount)
        {
            Value += amount.Value;
        }
    }
}