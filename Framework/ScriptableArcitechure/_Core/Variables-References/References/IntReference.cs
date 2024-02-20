using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class IntReference
    {
        [Tooltip("If set to true, the reference uses a constant value.")]
        public bool UseConstant = true;
        [Tooltip("The constant value. It is used if UseConstant is true.")]
        public int ConstantValue;
        [Tooltip("The IntVariable. Its value is used if UseConstant is false.")]
        public IntVariable Variable;
        public IntReference()
        { }

        public IntReference(int value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public int Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public void SetRefValue(int value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}