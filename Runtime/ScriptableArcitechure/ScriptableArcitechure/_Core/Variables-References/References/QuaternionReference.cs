using System;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A reference to a Quaternion. The reference can be either a constant value or a variable value.
    /// </summary>
    [Serializable]
    public class QuaternionReference
    {
        public bool UseConstant = true;
        public Quaternion ConstantValue;
        public QuaternionVariable Variable;

        /// <summary>
        /// Initializes a new instance of the QuaternionReference class with default values.
        /// Used to initialize the reference with default values, useful for when you want to use the reference as a Quaternion.
        /// </summary>
        public QuaternionReference()
        { }

        /// <summary>
        /// Initializes a new instance of the QuaternionReference class with a given constant value.
        /// Used to initialize the reference with a constant value, useful for when you want to use the reference as a Quaternion.
        /// </summary>
        /// <param name="value"></param>
        public QuaternionReference(Quaternion value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// Gets the value of the reference, which is either the constant value or the variable value, depending on UseConstant. 
        /// Used to get the value of the reference, useful for when you want to use the reference as a Quaternion.
        /// </summary>
        public Quaternion Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the value of the reference to the given value. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value"></param>
        public void SetRefValue(Quaternion value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        /// <summary>
        /// Implicit conversion to Quaternion. Used to convert the reference to a Quaternion, useful for when you want to use the reference as a Quaternion.
        /// </summary>
        /// <param name="reference"></param>
        public static implicit operator Quaternion(QuaternionReference reference)
        {
            return reference.Value;
        }
    }
}
