using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the AudioClipArrayReference type.
    /// </summary>
    [CustomPropertyDrawer(typeof(AudioClipArrayReference))]
    public class AudioClipArrayReferenceDrawer : ReferenceDrawer { }
}