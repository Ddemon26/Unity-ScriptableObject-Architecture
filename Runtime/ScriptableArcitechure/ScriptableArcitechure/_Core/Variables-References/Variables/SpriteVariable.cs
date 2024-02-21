using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Sprite variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Material/SpriteVariable")]
    public class SpriteVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the Sprite variable.
        /// </summary>
        [Tooltip("The value of the Sprite variable.")]
        public Sprite Value;

        /// <summary>
        /// Sets the value of the Sprite variable from a Sprite.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Sprite value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Sprite variable from another SpriteVariable.
        /// </summary>
        /// <param name="value">The SpriteVariable to get the new value from.</param>
        public void SetValue(SpriteVariable value)
        {
            Value = value.Value;
        }
    }
}