using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a float variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Variables/FloatVariable")]
    public class FloatVariable : ScriptableObject
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
        /// The value of the float variable.
        /// </summary>
        [Tooltip("The value of the float variable.")]
        public float Value;

        /// <summary>
        /// Sets the value of the float variable.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the float variable to the value of another FloatVariable.
        /// </summary>
        /// <param name="value">The other FloatVariable.</param>
        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Applies a change to the value of the float variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        /// <summary>
        /// Applies a change to the value of the float variable, using the value of another FloatVariable.
        /// </summary>
        /// <param name="amount">The other FloatVariable.</param>
        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }
    }
}