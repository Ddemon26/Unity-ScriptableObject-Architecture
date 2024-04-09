namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Abstract class for a reference to a value of type TValue, which can be stored in a ValueAsset of type TAsset.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <typeparam name="TAsset">The type of the ValueAsset that can store the value.</typeparam>
    public abstract class ValueReference<TValue, TAsset> where TAsset : ValueAsset<TValue>
    {
        /// <summary>
        /// Determines whether to use the constant value or the variable value.
        /// </summary>
        protected readonly bool useConstant = true;

        /// <summary>
        /// The constant value of type TValue.
        /// </summary>
        protected TValue constantValue;

        /// <summary>
        /// The variable of type TAsset that can store the value.
        /// </summary>
        public TAsset assetVariable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected ValueReference() { }

        /// <summary>
        /// Constructor that sets the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        protected ValueReference(TValue value)
        {
            useConstant = true;
            constantValue = value;
        }

        /// <summary>
        /// Gets the value, either the constant value or the variable value.
        /// </summary>
        public TValue Value => useConstant ? constantValue : assetVariable.value;

        /// <summary>
        /// Sets the value, either the constant value or the variable value.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetRefValue(TValue value)
        {
            if (useConstant)
                constantValue = value;
            else
                assetVariable.value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value, either the constant value or the variable value.</returns>
        public TValue GetValue() => Value;

        /// <summary>
        /// Implicit conversion operator from ValueReference to TValue.
        /// </summary>
        /// <param name="reference">The ValueReference to convert.</param>
        public static implicit operator TValue(ValueReference<TValue, TAsset> reference) => reference.Value;
    }
}