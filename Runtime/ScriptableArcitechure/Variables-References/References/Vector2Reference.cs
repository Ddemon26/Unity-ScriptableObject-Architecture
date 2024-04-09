using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Vector2 value, which can be stored in a Vector2Variable asset.
    /// </summary>
    [System.Serializable]
    public class Vector2Reference : ValueReference<Vector2, Vector2Variable>
    {
        /// <summary>
        /// Default constructor for Vector2Reference.
        /// </summary>
        public Vector2Reference() { }

        /// <summary>
        /// Constructor that sets the constant Vector2 value.
        /// </summary>
        /// <param name="value">The constant Vector2 value to set.</param>
        public Vector2Reference(Vector2 value) : base(value) { }
    }
}