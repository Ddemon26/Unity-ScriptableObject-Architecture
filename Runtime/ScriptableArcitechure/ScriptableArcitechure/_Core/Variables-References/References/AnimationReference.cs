using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to an Animation variable, which can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AnimationReference
    {
        /// <summary>
        /// Determines whether to use a constant or a variable.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant value.
        /// </summary>
        public AnimationClip ConstantValue;

        /// <summary>
        /// The variable value.
        /// </summary>
        public AnimationVariable Variable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnimationReference()
        { }

        /// <summary>
        /// Constructor with a constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public AnimationReference(AnimationClip value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// The value, which is either the constant value or the variable value.
        /// </summary>
        public AnimationClip Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the value, either as a constant value or as a variable value.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetRefValue(AnimationClip value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        /// <summary>
        /// Implicit conversion from an AnimationReference to an AnimationClip.
        /// </summary>
        /// <param name="reference">The AnimationReference to convert.</param>
        public static implicit operator AnimationClip(AnimationReference reference)
        {
            return reference.Value;
        }
    }
}