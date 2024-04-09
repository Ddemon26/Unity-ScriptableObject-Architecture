namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class BoolReference : ValueReference<bool, BoolVariable>
    {
        public BoolReference() { }
        
        public BoolReference(bool value) : base(value) { }
        
        public void ToggleValue(bool newValue)
        {
            if (UseConstant)
                ConstantValue = newValue;
            else
                Variable.SetValue(newValue);
        }
    }
}