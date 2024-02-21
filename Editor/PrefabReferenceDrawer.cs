using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the PrefabReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(PrefabReference))]
    public class PrefabReferenceDrawer : ReferenceDrawer {}
}