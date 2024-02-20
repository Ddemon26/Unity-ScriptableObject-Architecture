using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an array of AudioClips, which can be either a constant or a variable.
    /// </summary>
    [CreateAssetMenu(menuName = "Variables/AudioClipListVariable")]
    public class AudioClipListVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        public string DeveloperDescription = "";
#endif
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [Tooltip("The value of the variable.")]
        public AudioClip[] Value;
        /// <summary>
        /// Sets the value of the AudioClipListVariable.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(AudioClip[] value)
        {
            Value = value;
        }
        /// <summary>
        /// Sets the value of the AudioClipListVariable to the value of another AudioClipListVariable.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(AudioClipListVariable value)
        {
            Value = value.Value;
        }
    }
}