using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom property drawer for SpriteReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(SpriteReference))]
    public class SpriteReferenceDrawer : ReferenceDrawer {}
}