using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a reference to a Texture that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class TextureReference
    {
        [Tooltip("If true, use the constant value. If false, use the variable value.")]
        public bool UseConstant = true;

        [Tooltip("The constant value of the Texture.")]
        public Texture ConstantValue;

        [Tooltip("The variable value of the Texture.")]
        public TextureVariable Variable;

        /// <summary>
        /// The value of the Texture, which is either the constant value or the variable value.
        /// </summary>
        public Texture Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        /// <summary>
        /// Sets the value of the Texture, either as a constant or as a variable.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetRefValue(Texture value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }

        /// <summary>
        /// Implicit conversion operator from TextureReference to Texture.
        /// </summary>
        /// <param name="reference">The TextureReference to convert.</param>
        public static implicit operator Texture(TextureReference reference)
        {
            return reference.Value;
        }
    }
}