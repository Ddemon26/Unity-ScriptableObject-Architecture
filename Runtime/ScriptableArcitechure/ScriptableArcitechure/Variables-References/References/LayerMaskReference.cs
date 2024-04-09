using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a reference to a LayerMask that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class LayerMaskReference
    {
        /// <summary>
        /// Determines whether to use the constant value or the variable value.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant value of the LayerMask.
        /// </summary>
        public LayerMask ConstantValue;

        /// <summary>
        /// The variable value of the LayerMask.
        /// </summary>
        public LayerMaskVariable Variable;

        /// <summary>
        /// The value of the LayerMask, which is either the constant value or the variable value.
        /// </summary>
        public LayerMask Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        /// <summary>
        /// Sets the value of the LayerMask, either as a constant or as a variable.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetRefValue(LayerMask value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }

        /// <summary>
        /// Implicit conversion operator from LayerMaskReference to LayerMask.
        /// </summary>
        /// <param name="reference">The LayerMaskReference to convert.</param>
        public static implicit operator LayerMask(LayerMaskReference reference)
        {
            return reference.Value;
        }
    }
}