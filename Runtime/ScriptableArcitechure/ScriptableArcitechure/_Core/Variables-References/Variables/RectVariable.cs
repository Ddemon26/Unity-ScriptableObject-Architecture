using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Rect variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/RectVariable")]
    public class RectVariable : ScriptableObject
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
        /// The value of the Rect variable.
        /// </summary>
        public Rect Value;

        /// <summary>
        /// Sets the value of the Rect variable from a Rect.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Rect value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Rect variable from another RectVariable.
        /// </summary>
        /// <param name="value">The RectVariable to get the new value from.</param>
        public void SetValue(RectVariable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Applies a change to the value of the Rect variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        public void ApplyChange(Rect amount)
        {
            Value = new Rect(Value.position + amount.position, Value.size + amount.size);
        }

        /// <summary>
        /// Applies a change to the value of the Rect variable from another RectVariable.
        /// </summary>
        /// <param name="amount">The RectVariable to get the change amount from.</param>
        public void ApplyChange(RectVariable amount)
        {
            Value = new Rect(Value.position + amount.Value.position, Value.size + amount.Value.size);
        }
    }
}