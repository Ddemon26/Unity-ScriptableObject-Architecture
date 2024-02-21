using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a boolean variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/BoolVariable")]
    public class BoolVariable : ScriptableObject
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
        /// The value of the boolean variable.
        /// </summary>
        [SerializeField, Tooltip("The value of the boolean variable.")]
        private bool value = false;

        /// <summary>
        /// Gets or sets the value of the boolean variable.
        /// </summary>
        public bool Value
        {
            get { return value; }
            set { this.value = value; }
        }
        /// <summary>
        /// Sets the value of the boolean variable from another BoolVariable.
        /// </summary>
        /// <param name="value">The BoolVariable to get the new value from.</param>
        public void SetValue(BoolVariable value)
        {
            Value = value.Value;
        }
        public void SetTrue()
        {
            Value = true;
        }
        public void SetFalse()
        {
            Value = false;
        }
        public void Toggle()
        {
            Value = !Value;
        }
        /// <summary>
        /// Applies a change to the value of the boolean variable.
        /// </summary>
        /// <param name="value">The BoolVariable to get the change value from.</param>
        public void ApplyChange(BoolVariable value)
        {
            Value = value.Value;
        }
    }
}