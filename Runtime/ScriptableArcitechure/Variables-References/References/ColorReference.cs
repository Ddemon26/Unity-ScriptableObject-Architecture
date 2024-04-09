using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Color value, which can be stored in a ColorVariable asset.
    /// </summary>
    [System.Serializable]
    public class ColorReference : ValueReference<Color, ColorVariable>
    {
        /// <summary>
        /// Default constructor for ColorReference.
        /// </summary>
        public ColorReference() { }

        /// <summary>
        /// Constructor that sets the constant color value.
        /// </summary>
        /// <param name="value">The constant color value to set.</param>
        public ColorReference(Color value) : base(value) { }
    }
}