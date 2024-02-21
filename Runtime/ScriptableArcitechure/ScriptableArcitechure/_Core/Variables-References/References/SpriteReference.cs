using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a reference to a Sprite that can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class SpriteReference
    {
        /// <summary>
        /// Determines whether to use the constant value or the variable value.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant value of the Sprite.
        /// </summary>
        public Sprite ConstantValue;

        /// <summary>
        /// The variable value of the Sprite.
        /// </summary>
        public SpriteVariable Variable;

        /// <summary>
        /// The value of the Sprite, which is either the constant value or the variable value.
        /// </summary>
        public Sprite Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        /// <summary>
        /// Sets the value of the Sprite, either as a constant or as a variable.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetRefValue(Sprite value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }

        /// <summary>
        /// Implicit conversion operator from SpriteReference to Sprite.
        /// </summary>
        /// <param name="reference">The SpriteReference to convert.</param>
        public static implicit operator Sprite(SpriteReference reference)
        {
            return reference.Value;
        }
    }
}