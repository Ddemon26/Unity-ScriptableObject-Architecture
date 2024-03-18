using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the ScriptableObjectReference type.
    /// </summary>
    [CustomPropertyDrawer(typeof(ScriptableObjectReference))]
    public class ScriptableObjectReferenceDrawer : ReferenceDrawer {}
}