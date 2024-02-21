using UnityEngine;

namespace ScriptableArchitect.Variables
{
    //lets create a new reference for AnimationCurve
    [System.Serializable]
    public class AnimationCurveReference
    {
        public bool UseConstant = true;
        public AnimationCurve ConstantValue;
        public AnimationCurveVariable Variable;
        public AnimationCurveReference()
        { }

        public AnimationCurveReference(AnimationCurve value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public AnimationCurve Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public void SetRefValue(AnimationCurve value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        public static implicit operator AnimationCurve(AnimationCurveReference reference)
        {
            return reference.Value;
        }
    }
}