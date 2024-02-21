using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to an array of Material variables, which can be either a constant array or a variable.
    /// </summary>
    [System.Serializable]
    public class MaterialArrayReference
    {
        /// <summary>
        /// Determines whether to use a constant array or a variable.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant array of Material variables.
        /// </summary>
        public Material[] ConstantValue;

        /// <summary>
        /// The variable array of Material variables.
        /// </summary>
        public MaterialArrayVariable Variable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MaterialArrayReference()
        { }

        /// <summary>
        /// Constructor with a constant array of Material variables.
        /// </summary>
        /// <param name="value">The constant array of Material variables.</param>
        public MaterialArrayReference(Material[] value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// The array of Material variables, which is either the constant array or the variable array.
        /// </summary>
        public Material[] Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the array of Material variables, either as a constant array or as a variable array.
        /// </summary>
        /// <param name="value">The new array of Material variables.</param>
        public void SetRefValue(Material[] value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        /// <summary>
        /// Implicit conversion from a MaterialArrayReference to a Material array.
        /// </summary>
        /// <param name="reference">The MaterialArrayReference to convert.</param>
        public static implicit operator Material[](MaterialArrayReference reference)
        {
            return reference.Value;
        }
    }
}