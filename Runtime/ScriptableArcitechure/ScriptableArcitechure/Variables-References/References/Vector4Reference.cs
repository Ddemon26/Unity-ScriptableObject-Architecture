using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Vector4 value, which can be stored in a Vector4Variable asset.
    /// </summary>
    [System.Serializable]
    public class Vector4Reference : ValueReference<Vector4, Vector4Variable>
    {
        /// <summary>
        /// Default constructor for Vector4Reference.
        /// </summary>
        public Vector4Reference() { }

        /// <summary>
        /// Constructor that sets the constant Vector4 value.
        /// </summary>
        /// <param name="value">The constant Vector4 value to set.</param>
        public Vector4Reference(Vector4 value) : base(value) { }
    }
}