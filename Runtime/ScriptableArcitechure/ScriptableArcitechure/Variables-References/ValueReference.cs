namespace ScriptableArchitect.Variables
{
    public abstract class ValueReference<TValue, TAsset> where TAsset : ValueAsset<TValue>
    {
        public bool UseConstant = true;
        public TValue ConstantValue;
        public TAsset Variable;

        public ValueReference() { }

        public ValueReference(TValue value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public TValue Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        public void SetRefValue(TValue value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }
        
        public TValue GetValue()
        {
            return Value;
        }

        // Implicit conversion operator
        public static implicit operator TValue(ValueReference<TValue, TAsset> reference)
        {
            return reference.Value;
        }
    }
}