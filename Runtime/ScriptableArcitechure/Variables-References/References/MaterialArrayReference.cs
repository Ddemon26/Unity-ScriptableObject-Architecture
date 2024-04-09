using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Material array value, which can be stored in a MaterialArrayVariable asset.
    /// </summary>
    [System.Serializable]
    public class MaterialArrayReference : ValueReference<Material[], MaterialArrayVariable>
    {
        /// <summary>
        /// Default constructor for MaterialArrayReference.
        /// </summary>
        public MaterialArrayReference() { }

        /// <summary>
        /// Constructor that sets the constant Material array value.
        /// </summary>
        /// <param name="value">The constant Material array value to set.</param>
        public MaterialArrayReference(Material[] value) : base(value) { }
    }
}