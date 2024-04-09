using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an array of AudioClips, which can be either a constant or a variable.
    /// </summary>
    [System.Serializable]
    public class AudioClipArrayReference : ValueReference<AudioClip[], AudioClipArrayVariable>
    {
        public AudioClipArrayReference() { }
        
        public AudioClipArrayReference(AudioClip[] value) : base(value) { }
    }
}