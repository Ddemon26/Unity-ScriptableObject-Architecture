using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A custom property drawer for IntReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(IntReference))]
    public class IntReferenceDrawer : ReferenceDrawer { }
}