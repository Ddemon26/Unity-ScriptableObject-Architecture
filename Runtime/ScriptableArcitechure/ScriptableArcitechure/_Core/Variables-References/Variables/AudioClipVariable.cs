using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an AudioClip, which can be either a constant or a variable.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Audio/AudioClipVariable")]
    public class AudioClipVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        public string DeveloperDescription = "";
#endif
        [Tooltip("The value of the variable.")]
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public AudioClip Value;
        /// <summary>
        /// Sets the value of the AudioClipVariable.
        /// </summary>
        /// <param name="value">The AudioClip value to set.</param>
        public void SetValue(AudioClip value)
        {
            Value = value;
        }
        /// <summary>
        /// Sets the value of the AudioClipVariable to the value of another AudioClipVariable.
        /// </summary>
        /// <param name="value">The AudioClipVariable whose value to set.</param>
        public void SetValue(AudioClipVariable value)
        {
            Value = value.Value;
        }
    }
}