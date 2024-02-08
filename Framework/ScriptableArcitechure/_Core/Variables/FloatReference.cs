using System;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference a float value, which can be either a constant or a variable.
    /// </summary>
    [Serializable]
    public class FloatReference
    {
        /// <summary>
        /// If set to true, the reference uses a constant value.
        /// </summary>
        [Tooltip("If set to true, the reference uses a constant value.")]
        public bool UseConstant = true;
        /// <summary>
        /// The constant value. It is used if UseConstant is true.
        /// </summary>
        [Tooltip("The constant value. It is used if UseConstant is true.")]
        public float ConstantValue;
        /// <summary>
        /// The FloatVariable. Its value is used if UseConstant is false.
        /// </summary>
        [Tooltip("The FloatVariable. Its value is used if UseConstant is false.")]
        public FloatVariable Variable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FloatReference()
        { }
        /// <summary>
        /// Constructor that sets the constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        /// <summary>
        /// The value of the reference. It is either the constant value or the value of the variable, depending on UseConstant.
        /// </summary>
        public float Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
        /// <summary>
        /// Sets the value of the reference. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value"></param>
        public void SetRefValue(float value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
        /// <summary>
        /// Implicit conversion operator to float.
        /// </summary>
        /// <param name="reference">The FloatReference to convert.</param>
        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}