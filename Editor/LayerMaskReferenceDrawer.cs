using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the LayerMaskReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(LayerMaskReference))]
    public class LayerMaskReferenceDrawer : ReferenceDrawer {}
}