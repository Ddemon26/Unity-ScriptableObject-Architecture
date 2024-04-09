﻿using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to reference an AudioClip, which can be either a constant or a variable.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Audio/AudioClipVariable")]
    public class AudioClipVariable : ValueAsset<AudioClip>
    {
    }
}