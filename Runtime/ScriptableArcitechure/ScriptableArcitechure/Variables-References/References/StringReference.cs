using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a string that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class StringReference
    {
        /// <summary>
        /// Determines whether to use a constant value or a variable value.
        /// </summary>
        [Tooltip("Determines whether to use a constant value or a variable value.")]
        public bool UseConstant = true;
        /// <summary>
        /// The constant value of the string reference.
        /// </summary>
        [Tooltip("The constant value of the string reference.")]
        public string ConstantValue;
        /// <summary>
        /// The variable value of the string reference.
        /// </summary>
        [Tooltip("The variable value of the string reference.")]
        public StringVariable Variable;

        /// <summary>
        /// Initializes a new instance of the StringReference class with default values.
        /// </summary>
        public StringReference()
        { }
        /// <summary>
        /// Initializes a new instance of the StringReference class with a given constant value.
        /// </summary>
        /// <param name="value">The constant value to initialize with.</param>
        public StringReference(string value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        /// <summary>
        /// Gets the value of the reference. If UseConstant is true, the constant value is returned. Otherwise, the variable value is returned.
        /// </summary>
        public string Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
        /// <summary>
        /// Sets the value of the reference. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetRefValue(string value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
        /// <summary>
        /// Adds a value to the reference. If UseConstant is true, the value is added to the constant value. Otherwise, the value is added to the variable value.
        /// </summary>
        /// <param name="value"></param>
        public void AddToValue(string value)
        {
            if (UseConstant)
                ConstantValue += value;
            else
                Variable.Value += value;
        }
        /// <summary>
        /// Implicit conversion to string. Used to convert the reference to a string, useful for when you want to use the reference as a string.
        /// </summary>
        /// <param name="reference">The StringReference to convert.</param>
        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}