using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the AnimationReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(AnimationReference))]
    public class AnimationReferenceDrawer : ReferenceDrawer {}
}