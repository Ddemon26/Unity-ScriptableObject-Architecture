using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an AudioClip, which can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AudioClipReference
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
        public AudioClip ConstantValue;
        /// <summary>
        /// The AudioClipVariable. Its value is used if UseConstant is false.
        /// </summary>
        [Tooltip("The AudioClipVariable. Its value is used if UseConstant is false.")]
        public AudioClipVariable Variable;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public AudioClipReference()
        { }
        /// <summary>
        /// Constructor that sets the constant value.
        /// </summary>
        /// <param name="value">The constant AudioClip value.</param>
        public AudioClipReference(AudioClip value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        /// <summary>
        /// The value of the reference. It is either the constant value or the value of the variable, depending on UseConstant.
        /// </summary>
        public AudioClip Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
        /// <summary>
        /// Sets the value of the reference. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value">The AudioClip value to set.</param>
        public void SetRefValue(AudioClip value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
        /// <summary>
        /// Implicit conversion operator to AudioClip.
        /// </summary>
        /// <param name="reference">The AudioClipReference to convert.</param>
        public static implicit operator AudioClip(AudioClipReference reference)
        {
            return reference.Value;
        }
    }
}