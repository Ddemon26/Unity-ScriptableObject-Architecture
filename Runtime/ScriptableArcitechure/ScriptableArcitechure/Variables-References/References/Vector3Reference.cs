using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Vector3 value, which can be stored in a Vector3Variable asset.
    /// </summary>
    [System.Serializable]
    public class Vector3Reference : ValueReference<Vector3, Vector3Variable>
    {
        /// <summary>
        /// Default constructor for Vector3Reference.
        /// </summary>
        public Vector3Reference() { }

        /// <summary>
        /// Constructor that sets the constant Vector3 value.
        /// </summary>
        /// <param name="value">The constant Vector3 value to set.</param>
        public Vector3Reference(Vector3 value) : base(value) { }
    }
}