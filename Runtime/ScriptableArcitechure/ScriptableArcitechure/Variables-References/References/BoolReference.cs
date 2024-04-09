namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class BoolReference : ValueReference<bool, BoolVariable>
    {
        public BoolReference() { }
        
        public BoolReference(bool value) : base(value) { }
        
        public void ToggleValue(bool newValue)
        {
            if (useConstant)
                constantValue = newValue;
            else
                assetVariable.SetValue(newValue);
        }
    }
}