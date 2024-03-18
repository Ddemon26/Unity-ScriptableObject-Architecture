using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the TextureReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(TextureReference))]
    public class TextureReferenceDrawer : ReferenceDrawer {}
}