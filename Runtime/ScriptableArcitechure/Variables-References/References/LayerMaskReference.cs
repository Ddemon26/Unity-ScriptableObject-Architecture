using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a LayerMask value, which can be stored in a LayerMaskVariable asset.
    /// </summary>
    [System.Serializable]
    public class LayerMaskReference : ValueReference<LayerMask, LayerMaskVariable>
    {
        /// <summary>
        /// Default constructor for LayerMaskReference.
        /// </summary>
        public LayerMaskReference() { }

        /// <summary>
        /// Constructor that sets the constant LayerMask value.
        /// </summary>
        /// <param name="value">The constant LayerMask value to set.</param>
        public LayerMaskReference(LayerMask value) : base(value) { }
    }
}