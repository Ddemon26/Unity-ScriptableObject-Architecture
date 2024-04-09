using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class Vector3Reference
    {
        public bool UseConstant = true;
        public Vector3 ConstantValue;
        public Vector3Variable Variable;

        /// <summary>
        /// initializes a new instance of the Vector3Reference class with default values.
        /// used to initialize the reference with default values, useful for when you want to use the reference as a Vector3
        /// </summary>
        public Vector3Reference()
        { }
        /// <summary>
        /// initializes a new instance of the Vector3Reference class with a given constant value.
        /// used to initialize the reference with a constant value, useful for when you want to use the reference as a Vector3
        /// </summary>
        /// <param name="value"></param>
        public Vector3Reference(Vector3 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        /// <summary>
        /// Gets the value of the reference, which is either the constant value or the variable value, depending on UseConstant. 
        /// used to get the value of the reference, useful for when you want to use the reference as a Vector3
        /// </summary>
        public Vector3 Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }
        /// <summary>
        /// Sets the value of the reference to the given value. If UseConstant is true, the constant value is set. Otherwise, the variable value is set.
        /// </summary>
        /// <param name="value"></param>
        public void SetRefValue(Vector3 value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }

        /// <summary>
        /// implicit conversion to Vector3. used to convert the reference to a Vector3, useful for when you want to use the reference as a Vector3
        /// </summary>
        /// <param name="reference"></param>
        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}