namespace ScriptableArchitect.Variables
{
    public abstract class ValueReference<TValue, TAsset> where TAsset : ValueAsset<TValue>
    {
        public bool useConstant = true;
        public TValue constantValue;
        public TAsset assetVariable;

        public ValueReference() { }

        public ValueReference(TValue value)
        {
            useConstant = true;
            constantValue = value;
        }

        public TValue Value => useConstant || assetVariable == null ? constantValue : assetVariable.value;

        public void SetRefValue(TValue value)
        {
            if (useConstant)
                constantValue = value;
            else
                assetVariable.value = value;
        }

        public TValue GetValue() => Value;

        public static implicit operator TValue(ValueReference<TValue, TAsset> reference) => reference == null ? default : reference.Value;
    }
}