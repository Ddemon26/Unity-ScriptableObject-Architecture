using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a float variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the float variable.
        /// </summary>
        [Tooltip("The value of the float variable.")]
        public float Value;

        /// <summary>
        /// Determines whether the value of the float variable will be clamped between the MinValue and MaxValue.
        /// </summary>
        [Tooltip("If true, the value of the float variable will be clamped between the MinValue and MaxValue.")]
        public bool UseMinMaxSlider = false;

        /// <summary>
        /// The minimum value of the float variable.
        /// </summary>
        [Tooltip("The minimum value of the float variable.")]
        [ConditionalHide("UseMinMaxSlider", true)]
        public float MinValue = 0;

        /// <summary>
        /// The maximum value of the float variable.
        /// </summary>
        [Tooltip("The maximum value of the float variable.")]
        [ConditionalHide("UseMinMaxSlider", true)]
        public float MaxValue = 1;

        /// <summary>
        /// Validates the value of the float variable.
        /// </summary>
        private void OnValidate()
        {
            if (UseMinMaxSlider)
            {
                Value = Mathf.Clamp(Value, MinValue, MaxValue);
            }
        }

        /// <summary>
        /// Sets the value of the float variable from a float, clamping it between the MinValue and MaxValue if UseMinMaxSlider is true.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValueWithClamp(float value)
        {
            Value = UseMinMaxSlider ? Mathf.Clamp(value, MinValue, MaxValue) : value;
        }

        /// <summary>
        /// Sets the value of the float variable from a float.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the float variable from another FloatVariable.
        /// </summary>
        /// <param name="value">The FloatVariable to get the new value from.</param>
        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Increases the value of the float variable by a specified amount.
        /// </summary>
        /// <param name="amount">The amount to increase the value by.</param>
        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        /// <summary>
        /// Increases the value of the float variable by the value of another FloatVariable.
        /// </summary>
        /// <param name="amount">The FloatVariable to get the increase amount from.</param>
        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }

        /// <summary>
        /// Sets the value of the float variable from a string.
        /// </summary>
        /// <param name="value">The string to parse the new value from.</param>
        public void SetValueFromString(string value)
        {
            Value = float.Parse(value);
        }
    }
}
