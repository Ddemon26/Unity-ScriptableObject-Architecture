using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an AudioClip, which can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AudioClipReference : ValueReference<AudioClip, AudioClipVariable>
    {
        public AudioClipReference() { }
        
        public AudioClipReference(AudioClip value) : base(value) { }
    }
}