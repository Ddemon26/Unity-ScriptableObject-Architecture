using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a String value, which can be stored in a StringVariable asset.
    /// </summary>
    [System.Serializable]
    public class StringReference : ValueReference<string, StringVariable>
    {
        /// <summary>
        /// Default constructor for StringReference.
        /// </summary>
        public StringReference() { }

        /// <summary>
        /// Constructor that sets the constant string value.
        /// </summary>
        /// <param name="value">The constant string value to set.</param>
        public StringReference(string value) : base(value) { }
    }
}