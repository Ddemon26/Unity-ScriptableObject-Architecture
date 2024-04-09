using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to an array of prefabs, which can either be a constant array or a variable.
    /// </summary>
    [System.Serializable]
    public class PrefabArrayReference
    {
        /// <summary>
        /// Determines whether to use a constant value. If true, ConstantValue is used, otherwise Variable is used.
        /// </summary>
        public bool UseConstant = true;

        /// <summary>
        /// The constant array of GameObjects to use if UseConstant is true.
        /// </summary>
        public GameObject[] ConstantValue;

        /// <summary>
        /// The PrefabArrayVariable to use if UseConstant is false.
        /// </summary>
        public PrefabArrayVariable Variable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PrefabArrayReference()
        { }

        /// <summary>
        /// Constructor that initializes the PrefabArrayReference with a constant value.
        /// </summary>
        /// <param name="value">The constant value to initialize with.</param>
        public PrefabArrayReference(GameObject[] value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        /// <summary>
        /// The value of the PrefabArrayReference. This will be either ConstantValue or Variable.Value, depending on the value of UseConstant.
        /// </summary>
        public GameObject[] Value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        /// <summary>
        /// Sets the value of the PrefabArrayReference. If UseConstant is true, sets ConstantValue, otherwise sets Variable.Value.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetRefValue(GameObject[] value)
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.value = value;
        }

        /// <summary>
        /// Implicit conversion operator from PrefabArrayReference to GameObject[].
        /// </summary>
        /// <param name="reference">The PrefabArrayReference to convert.</param>
        public static implicit operator GameObject[](PrefabArrayReference reference)
        {
            return reference.Value;
        }
    }
}