using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to an array of colors that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class ColorArrayReference
    {
        /// <summary>
        /// Determines whether to use the constant value. If false, the variable value is used.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant array of colors.
        /// </summary>
        public Color[] ConstantValue;

        /// <summary>
        /// The variable array of colors.
        /// </summary>
        public ColorArrayVariable Variable;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorArrayReference"/> class.
        /// </summary>
        public ColorArrayReference()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorArrayReference"/> class with a constant value.
        /// </summary>
        /// <param name="value">The constant array of colors.</param>
        public ColorArrayReference(Color[] value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// Gets the value of the color array reference, which is either the constant or the variable value.
        /// </summary>
        public Color[] Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the value of the color array reference.
        /// </summary>
        /// <param name="value">The new array of colors.</param>
        public void SetRefValue(Color[] value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
    }
}