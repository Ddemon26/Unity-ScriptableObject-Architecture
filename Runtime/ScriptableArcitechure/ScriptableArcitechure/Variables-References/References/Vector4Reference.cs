using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Vector4 reference that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class Vector4Reference
    {
        public bool UseConstant = true;
        public Vector4 ConstantValue;
        public Vector4Variable Variable;

        /// <summary>
        /// Initializes a new instance of the Vector4Reference class with default values.
        /// </summary>
        public Vector4Reference()
        { }

        /// <summary>
        /// Initializes a new instance of the Vector4Reference class with a given constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public Vector4Reference(Vector4 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// Gets the value of the reference, which is either the constant value or the variable value, depending on UseConstant.
        /// </summary>
        public Vector4 Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        /// <summary>
        /// Sets the value of the reference to the given value. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetRefValue(Vector4 value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }

        /// <summary>
        /// Implicit conversion operator to Vector4.
        /// </summary>
        /// <param name="reference">The Vector4Reference to convert.</param>
        public static implicit operator Vector4(Vector4Reference reference)
        {
            return reference.Value;
        }
    }
}