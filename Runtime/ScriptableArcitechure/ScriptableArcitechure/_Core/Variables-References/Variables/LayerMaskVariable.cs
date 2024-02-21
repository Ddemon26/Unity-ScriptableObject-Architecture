using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a LayerMask variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/GameObject/LayerMaskVariable")]
    public class LayerMaskVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        public string DeveloperDescription = "";
#endif

        [Tooltip("The value of the LayerMask variable.")]
        /// <summary>
        /// The current value of the LayerMask variable.
        /// </summary>
        public LayerMask Value;

        /// <summary>
        /// Sets the value of the LayerMask variable from a LayerMask.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(LayerMask value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the LayerMask variable from another LayerMaskVariable.
        /// </summary>
        /// <param name="value">The LayerMaskVariable to get the new value from.</param>
        public void SetValue(LayerMaskVariable value)
        {
            Value = value.Value;
        }
    }
}