using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a reference to a ScriptableObject that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class ScriptableObjectReference
    {
        /// <summary>
        /// Determines whether to use the constant value or the variable value.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant value of the ScriptableObject.
        /// </summary>
        public ScriptableObject ConstantValue;

        /// <summary>
        /// The variable value of the ScriptableObject.
        /// </summary>
        public ScriptableObjectVariable Variable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ScriptableObjectReference()
        { }

        /// <summary>
        /// Constructor that sets the constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public ScriptableObjectReference(ScriptableObject value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// The value of the ScriptableObject, which is either the constant value or the variable value.
        /// </summary>
        public ScriptableObject Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the value of the ScriptableObject, either as a constant or as a variable.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetRefValue(ScriptableObject value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.SetValue(value);
        }

        /// <summary>
        /// Implicit conversion operator from ScriptableObjectReference to ScriptableObject.
        /// </summary>
        /// <param name="reference">The ScriptableObjectReference to convert.</param>
        public static implicit operator ScriptableObject(ScriptableObjectReference reference)
        {
            return reference.Value;
        }
    }
}