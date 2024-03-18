using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A custom property drawer for FloatReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDrawer : ReferenceDrawer { }
}