using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Rect value, which can be stored in a RectVariable asset.
    /// </summary>
    [System.Serializable]
    public class RectReference : ValueReference<Rect, RectVariable>
    {
        /// <summary>
        /// Default constructor for RectReference.
        /// </summary>
        public RectReference() { }

        /// <summary>
        /// Constructor that sets the constant Rect value.
        /// </summary>
        /// <param name="value">The constant Rect value to set.</param>
        public RectReference(Rect value) : base(value) { }
    }
}