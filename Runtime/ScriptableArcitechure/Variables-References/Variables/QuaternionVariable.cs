using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Quaternion variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/QuaternionVariable")]
    public class QuaternionVariable : ValueAsset<Quaternion>
    {
        /// <summary>
        /// Applies a change to the value of the Quaternion variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Quaternion amount)
        {
            SetValue(value *= amount);
        }
        /// <summary>
        /// Applies a change to the value of the Quaternion variable from another QuaternionVariable.
        /// </summary>
        /// <param name="amount">The QuaternionVariable to get the change amount from.</param>
        public void ApplyChange(QuaternionVariable amount)
        {
            SetValue(value *= amount.value);
        }
    }
}