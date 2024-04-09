using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a PrefabVariable, which can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class PrefabReference
    {
        /// <summary>
        /// Determines whether to use a constant or a variable.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant value.
        /// </summary>
        public GameObject ConstantValue;

        /// <summary>
        /// The variable value.
        /// </summary>
        public PrefabVariable Variable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PrefabReference()
        { }

        /// <summary>
        /// Constructor with a constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public PrefabReference(GameObject value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// The value, which is either the constant value or the variable value.
        /// </summary>
        public GameObject Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        /// <summary>
        /// Sets the value, either as a constant value or as a variable value.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetRefValue(GameObject value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }

        /// <summary>
        /// Implicit conversion from a PrefabReference to a GameObject.
        /// </summary>
        /// <param name="reference">The PrefabReference to convert.</param>
        public static implicit operator GameObject(PrefabReference reference)
        {
            return reference.Value;
        }
    }
}