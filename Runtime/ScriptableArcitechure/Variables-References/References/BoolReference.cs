namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a boolean value, which can be stored in a BoolVariable asset.
    /// </summary>
    [System.Serializable]
    public class BoolReference : ValueReference<bool, BoolVariable>
    {
        /// <summary>
        /// Default constructor for BoolReference.
        /// </summary>
        public BoolReference() { }

        /// <summary>
        /// Constructor that sets the constant boolean value.
        /// </summary>
        /// <param name="value">The constant boolean value to set.</param>
        public BoolReference(bool value) : base(value) { }

        /// <summary>
        /// Toggles the value of the boolean reference.
        /// If the reference is set to use a constant value, the constant value is toggled.
        /// If the reference is set to use a variable value, the value of the variable is toggled.
        /// </summary>
        /// <param name="newValue">The new value to set.</param>
        public void ToggleValue(bool newValue)
        {
            if (useConstant)
                constantValue = newValue;
            else
                assetVariable.SetValue(newValue);
        }
    }
}