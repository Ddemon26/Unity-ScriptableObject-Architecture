using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a reference to a MaterialVariable.
    /// </summary>
    [System.Serializable]
    public class MaterialReference
    {
        /// <summary>
        /// Determines whether to use the constant value or the variable value.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant value of the Material.
        /// </summary>
        public Material ConstantValue;

        /// <summary>
        /// The variable value of the Material.
        /// </summary>
        public MaterialVariable Variable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MaterialReference()
        { }

        /// <summary>
        /// Constructor that sets the constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public MaterialReference(Material value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// The value of the Material, either the constant value or the variable value.
        /// </summary>
        public Material Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        /// <summary>
        /// Sets the value of the Material, either the constant value or the variable value.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetRefValue(Material value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }

        /// <summary>
        /// Implicit conversion operator from MaterialReference to Material.
        /// </summary>
        /// <param name="reference">The MaterialReference to convert.</param>
        public static implicit operator Material(MaterialReference reference)
        {
            return reference.Value;
        }
    }
}