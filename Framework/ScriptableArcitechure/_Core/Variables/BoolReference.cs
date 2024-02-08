using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Boolean value, which can either be a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class BoolReference
    {
        /// <summary>
        /// Determines whether to use the constant value. If false, the variable value is used.
        /// </summary>
        [Tooltip("Determines whether to use the constant value. If false, the variable value is used.")]
        public bool UseConstant = true;

        /// <summary>
        /// The constant value of the Boolean reference.
        /// </summary>
        [Tooltip("The constant value of the Boolean reference.")]
        public bool ConstantValue;

        /// <summary>
        /// The variable value of the Boolean reference.
        /// </summary>
        [Tooltip("The variable value of the Boolean reference.")]
        public BoolVariable Variable;

        /// <summary>
        /// Initializes a new instance of the BoolReference class with default values.
        /// </summary>
        public BoolReference()
        { }

        /// <summary>
        /// Initializes a new instance of the BoolReference class with a given constant value.
        /// </summary>
        /// <param name="value">The constant value to initialize with.</param>
        public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// Gets the value of the Boolean reference, which is either the constant value or the variable value, depending on UseConstant.
        /// </summary>
        [Tooltip("Gets the value of the Boolean reference, which is either the constant value or the variable value, depending on UseConstant.")]
        public bool Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the value of the Boolean reference to the given value. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value"></param>
        public void SetRefValue(bool value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        /// <summary>
        /// Implicit conversion operator from BoolReference to bool.
        /// </summary>
        /// <param name="reference">The BoolReference to convert.</param>
        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }
    }
}