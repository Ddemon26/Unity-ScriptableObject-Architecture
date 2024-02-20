using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an array of AudioClips, which can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AudioClipListReference
    {
        [Tooltip("If set to true, the reference uses a constant value.")]
        public bool UseConstant = true;
        [Tooltip("The constant value. It is used if UseConstant is true.")]
        public AudioClip[] ConstantValue;
        [Tooltip("The AudioClipListVariable. Its value is used if UseConstant is false.")]
        public AudioClipListVariable Variable;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public AudioClipListReference()
        { }
        /// <summary>
        /// Constructor that sets the constant value.
        /// </summary>
        /// <param name="value"></param>
        public AudioClipListReference(AudioClip[] value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        /// <summary>
        /// The value of the reference. It is either the constant value or the value of the variable, depending on UseConstant.
        /// </summary>
        public AudioClip[] Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
        /// <summary>
        /// Sets the value of the reference. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value"></param>
        public void SetRefValue(AudioClip[] value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
        /// <summary>
        /// Implicit conversion operator to AudioClip[].
        /// </summary>
        /// <param name="reference"></param>
        public static implicit operator AudioClip[](AudioClipListReference reference)
        {
            return reference.Value;
        }
    }
}