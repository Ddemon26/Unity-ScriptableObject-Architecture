using UnityEngine;

namespace ScriptableArchitect.Variables
{
    public abstract class MinMaxValueAsset<T> : ValueAsset<T> where T : System.IComparable<T>
    {
        [Tooltip("If true, the value of the variable will be clamped between the MinValue and MaxValue.")]
        public bool useMinMaxSlider = false;
        [Tooltip("The minimum value of the variable.")]
        [ConditionalHide("useMinMaxSlider", true)]
        public T minValue;
        [Tooltip("The maximum value of the variable.")]
        [ConditionalHide("useMinMaxSlider", true)]
        public T maxValue;

        public override void SetValue(T refValue)
        {
            if (useMinMaxSlider)
            {
                if (refValue.CompareTo(minValue) < 0)
                {
                    Value = minValue;
                }
                else if (refValue.CompareTo(maxValue) > 0)
                {
                    Value = maxValue;
                }
                else
                {
                    Value = refValue;
                }
            }
            else
            {
                Value = refValue;
            }
        }

        public override void SetValue(ValueAsset<T> refValue)
        {
            if (useMinMaxSlider)
            {
                if (refValue.Value.CompareTo(minValue) < 0)
                {
                    Value = minValue;
                }
                else if (refValue.Value.CompareTo(maxValue) > 0)
                {
                    Value = maxValue;
                }
                else
                {
                    Value = refValue.Value;
                }
            }
            else
            {
                Value = refValue.Value;
            }
        }
    }
}