using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Rect variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/RectVariable")]
    public class RectVariable : ValueAsset<Rect>
    {
        /// <summary>
        /// Applies a change to the value of the Rect variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Rect amount)
        {
            SetValue(value = new Rect(value.position + amount.position, value.size + amount.size));
        }
        /// <summary>
        /// Applies a change to the value of the Rect variable from another RectVariable.
        /// </summary>
        /// <param name="amount">The RectVariable to get the change amount from.</param>
        public void ApplyChange(RectVariable amount)
        {
            SetValue(value = new Rect(value.position + amount.value.position, value.size + amount.value.size));
        }
    }
}