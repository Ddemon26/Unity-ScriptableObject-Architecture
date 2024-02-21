using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a reference to an Animator that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AnimatorReference
    {
        public bool UseConstant = true;
        public Animator ConstantValue;
        public AnimatorVariable Variable;

        /// <summary>
        /// Initializes a new instance of the AnimatorReference class with default values.
        /// </summary>
        public AnimatorReference()
        { }

        /// <summary>
        /// Initializes a new instance of the AnimatorReference class with a given constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public AnimatorReference(Animator value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// Gets the value of the reference, which is either the constant value or the variable value, depending on UseConstant.
        /// </summary>
        public Animator Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the value of the reference to the given value. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetRefValue(Animator value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        /// <summary>
        /// Implicit conversion operator to Animator.
        /// </summary>
        /// <param name="reference">The AnimatorReference to convert.</param>
        public static implicit operator Animator(AnimatorReference reference)
        {
            return reference.Value;
        }
    }
}