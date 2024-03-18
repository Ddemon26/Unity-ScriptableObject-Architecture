using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom property drawer for MaterialReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(MaterialReference))]
    public class MaterialReferenceDrawer : ReferenceDrawer {}
}