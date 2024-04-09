using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Material value, which can be stored in a MaterialVariable asset.
    /// </summary>
    [System.Serializable]
    public class MaterialReference : ValueReference<Material, MaterialVariable>
    {
        /// <summary>
        /// Default constructor for MaterialReference.
        /// </summary>
        public MaterialReference() { }

        /// <summary>
        /// Constructor that sets the constant Material value.
        /// </summary>
        /// <param name="value">The constant Material value to set.</param>
        public MaterialReference(Material value) : base(value) { }
    }
}