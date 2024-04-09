using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to an Animator value, which can be stored in an AnimatorVariable asset.
    /// </summary>
    [System.Serializable]
    public class AnimatorReference : ValueReference<Animator, AnimatorVariable>
    {
        /// <summary>
        /// Default constructor for AnimatorReference.
        /// </summary>
        public AnimatorReference() { }

        /// <summary>
        /// Constructor that sets the constant Animator value.
        /// </summary>
        /// <param name="value">The constant Animator value to set.</param>
        public AnimatorReference(Animator value) : base(value) { }
    }
}