namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class IntReference : ValueReference<int, IntVariable>
    {
        public IntReference() { }

        public IntReference(int value) : base(value) { }
    }
}