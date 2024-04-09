using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a reference to an Animator that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AnimatorReference : ValueReference<Animator, AnimatorVariable>
    {
        /// <summary>
        /// Initializes a new instance of the AnimatorReference class with default values.
        /// </summary>
        public AnimatorReference() { }
        
        public AnimatorReference(Animator value) : base(value) { }
    }
}