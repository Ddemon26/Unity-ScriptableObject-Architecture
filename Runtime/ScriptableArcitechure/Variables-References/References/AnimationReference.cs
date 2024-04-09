using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to an Animation variable, which can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AnimationReference : ValueReference<AnimationClip, AnimationVariable>
    {
        public AnimationReference() { }
        
        public AnimationReference(AnimationClip value) : base(value) { }
    }
}