using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom property drawer for ColorArrayReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(ColorArrayReference))]
    public class ColorArrayReferenceDrawer : ReferenceDrawer {}
}