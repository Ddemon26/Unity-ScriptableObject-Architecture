using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Rect reference that can be used as a variable.
    /// </summary>
    [System.Serializable]
    public class RectReference
    {
        public bool UseConstant = true;
        public Rect ConstantValue;
        public RectVariable Variable;

        public RectReference()
        { }
        public RectReference(Rect value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        public Rect Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
        public void SetRefValue(Rect value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        public static implicit operator Rect(RectReference reference)
        {
            return reference.Value;
        }
    }
}