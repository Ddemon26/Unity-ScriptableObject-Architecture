using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A custom property drawer for MaterialArrayReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(MaterialArrayReference))]
    public class MaterialArrayReferenceDrawer : ReferenceDrawer { }
}