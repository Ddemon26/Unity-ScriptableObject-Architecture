using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Quaternion variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/QuaternionVariable")]
    public class QuaternionVariable : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The value of the Quaternion variable.
        /// </summary>
        public Quaternion Value;

        /// <summary>
        /// Sets the value of the Quaternion variable from a Quaternion.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Quaternion value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Quaternion variable from another QuaternionVariable.
        /// </summary>
        /// <param name="value">The QuaternionVariable to get the new value from.</param>
        public void SetValue(QuaternionVariable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Applies a change to the value of the Quaternion variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Quaternion amount)
        {
            Value *= amount;
        }

        /// <summary>
        /// Applies a change to the value of the Quaternion variable from another QuaternionVariable.
        /// </summary>
        /// <param name="amount">The QuaternionVariable to get the change amount from.</param>
        public void ApplyChange(QuaternionVariable amount)
        {
            Value *= amount.Value;
        }
    }
}