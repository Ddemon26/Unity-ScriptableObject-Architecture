using UnityEngine;

namespace ScriptableArchitect.Variables
{
    //lets create a new reference for AnimationCurve
    [System.Serializable]
    public class AnimationCurveReference : ValueReference<AnimationCurve, AnimationCurveVariable>
    {
        public AnimationCurveReference() { }
        
        public AnimationCurveReference(AnimationCurve value) : base(value) { }
    }
}