using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Texture variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Material/TextureVariable")]
    public class TextureVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the Texture variable.
        /// </summary>
        [Tooltip("The value of the Texture variable.")]
        public Texture Value;

        /// <summary>
        /// Sets the value of the Texture variable from a Texture.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Texture value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Texture variable from another TextureVariable.
        /// </summary>
        /// <param name="value">The TextureVariable to get the new value from.</param>
        public void SetValue(TextureVariable value)
        {
            Value = value.Value;
        }
    }
}