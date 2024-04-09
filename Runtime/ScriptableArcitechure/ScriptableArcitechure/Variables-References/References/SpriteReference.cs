using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Sprite value, which can be stored in a SpriteVariable asset.
    /// </summary>
    [System.Serializable]
    public class SpriteReference : ValueReference<Sprite, SpriteVariable>
    {
        /// <summary>
        /// Default constructor for SpriteReference.
        /// </summary>
        public SpriteReference() { }

        /// <summary>
        /// Constructor that sets the constant Sprite value.
        /// </summary>
        /// <param name="value">The constant Sprite value to set.</param>
        public SpriteReference(Sprite value) : base(value) { }
    }
}