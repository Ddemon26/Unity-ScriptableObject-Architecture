using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A custom property drawer for StringReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(StringReference))]
    public class StringReferenceDrawer : ReferenceDrawer { }
}