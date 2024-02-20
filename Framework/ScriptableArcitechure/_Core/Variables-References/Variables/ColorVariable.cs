using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a color variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Variables/ColorVariable")]
    public class ColorVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif
        /// <summary>
        /// The current value of the color variable.
        /// </summary>
        public Color Value;
        /// <summary>
        /// Sets the value of the color variable from a color.
        /// </summary>
        /// <param name="value">The color to set the variable to.</param>
        public void SetValue(Color value)
        {
            Value = value;
        }
        /// <summary>
        /// Sets the value of the color variable from another ColorVariable.
        /// </summary>
        /// <param name="value">The ColorVariable to set the variable to.</param>
        public void SetValue(ColorVariable value)
        {
            Value = value.Value;
        }
    }
}
