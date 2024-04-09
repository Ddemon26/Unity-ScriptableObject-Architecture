using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Texture value, which can be stored in a TextureVariable asset.
    /// </summary>
    [System.Serializable]
    public class TextureReference : ValueReference<Texture, TextureVariable>
    {
        /// <summary>
        /// Default constructor for TextureReference.
        /// </summary>
        public TextureReference() { }

        /// <summary>
        /// Constructor that sets the constant Texture value.
        /// </summary>
        /// <param name="value">The constant Texture value to set.</param>
        public TextureReference(Texture value) : base(value) { }
    }
}