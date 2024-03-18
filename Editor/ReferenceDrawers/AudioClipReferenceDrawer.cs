using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the AudioClipReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(AudioClipReference))]
    public class AudioClipReferenceDrawer : ReferenceDrawer { }
}