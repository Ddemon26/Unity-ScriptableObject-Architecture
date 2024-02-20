using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a color reference that can be either a constant color or a variable color.
    /// </summary>
    [System.Serializable]
    public class ColorReference
    {
        /// <summary>
        /// Whether to use a constant value or a variable value.
        /// </summary>
        public bool UseConstant = true;
        /// <summary>
        /// The constant value of the color reference.
        /// </summary>
        public Color ConstantValue;
        /// <summary>
        /// The variable value of the color reference.
        /// </summary>
        public ColorVariable Variable;
        /// <summary>
        /// Creates a new color reference with default values.
        /// </summary>
        public ColorReference()
        { }
        /// <summary>
        /// Creates a new color reference with a constant value.
        /// </summary>
        /// <param name="value">The constant color value.</param>
        public ColorReference(Color value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        /// <summary>
        /// The color value of the reference. It is either the constant color value or the color value of the variable, depending on UseConstant.
        /// </summary>
        public Color Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
        /// <summary>
        /// Sets the color value of the reference. If UseConstant is true, the constant color value is set. Otherwise, the color value of the variable is set.
        /// </summary>
        /// <param name="value">The color value to set.</param>
        public void SetRefValue(Color value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
    }
}