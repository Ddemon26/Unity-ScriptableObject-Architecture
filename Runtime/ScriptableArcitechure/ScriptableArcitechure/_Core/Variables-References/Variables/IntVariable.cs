using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents an int variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/IntVariable")]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif
        /// <summary>
        /// The current value of the int variable.
        /// </summary>
        [Tooltip("The value of the int variable.")]
        public int Value;
        /// <summary>
        /// Determines whether the value of the int variable will be clamped between the MinValue and MaxValue.
        /// </summary>
        [Tooltip("If true, the value of the int variable will be clamped between the MinValue and MaxValue.")]
        public bool UseMinMaxSlider = false;
        /// <summary>
        /// The minimum value of the int variable.
        /// </summary>
        [Tooltip("The minimum value of the int variable.")]
        [ConditionalHide("UseMinMaxSlider", true)]
        public int MinValue = 0;
        /// <summary>
        /// The maximum value of the int variable.
        /// </summary>
        [Tooltip("The maximum value of the int variable.")]
        [ConditionalHide("UseMinMaxSlider", true)]
        public int MaxValue = 1;

        private void OnValidate()
        {
            if (UseMinMaxSlider)
            {
                Value = Mathf.Clamp(Value, MinValue, MaxValue);
            }
        }
        /// <summary>
        /// Sets the value of the int variable from an int, clamping it between the MinValue and MaxValue.
        /// </summary>
        /// <param name="value"></param>
        public void SetValueWithClamp(int value)
        {
            Value = Mathf.Clamp(value, MinValue, MaxValue);
        }
        /// <summary>
        /// Sets the value of the int variable from an int.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(int value)
        {
            Value = value;
        }
        /// <summary>
        /// Sets the value of the int variable from another IntVariable.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }
        /// <summary>
        /// Increases the value of the int variable by a specified amount.
        /// </summary>
        /// <param name="amount"></param>
        public void ApplyChange(int amount)
        {
            Value += amount;
        }
        /// <summary>
        /// Increases the value of the int variable by the value of another IntVariable.
        /// </summary>
        /// <param name="amount"></param>
        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }
        /// <summary>
        /// Sets the value of the int variable from a string.
        /// </summary>
        /// <param name="value"></param>
        public void SetValueFromString(string value)
        {
            Value = int.Parse(value);
        }
    }
}