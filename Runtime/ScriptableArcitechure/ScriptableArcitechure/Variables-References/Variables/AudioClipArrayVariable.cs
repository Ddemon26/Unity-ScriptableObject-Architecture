using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an array of AudioClips, which can be either a constant or a variable.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Audio/AudioClipArrayVariable")]
    public class AudioClipArrayVariable : ValueAsset<AudioClip[]>
    {
    }
}
