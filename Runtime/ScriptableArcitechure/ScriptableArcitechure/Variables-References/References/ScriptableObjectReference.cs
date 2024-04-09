using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a ScriptableObject value, which can be stored in a ScriptableObjectVariable asset.
    /// </summary>
    [System.Serializable]
    public class ScriptableObjectReference : ValueReference<ScriptableObject, ScriptableObjectVariable>
    {
        /// <summary>
        /// Default constructor for ScriptableObjectReference.
        /// </summary>
        public ScriptableObjectReference() { }

        /// <summary>
        /// Constructor that sets the constant ScriptableObject value.
        /// </summary>
        /// <param name="value">The constant ScriptableObject value to set.</param>
        public ScriptableObjectReference(ScriptableObject value) : base(value) { }
    }
}