using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the AnimationCurveReference type.
    /// </summary>
    [CustomPropertyDrawer(typeof(AnimationCurveReference))]
    public class AnimationCurveReferenceDrawer : ReferenceDrawer {}
}