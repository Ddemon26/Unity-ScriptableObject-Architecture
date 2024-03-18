using UnityEditor;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom property drawer for PrefabArrayReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(PrefabArrayReference))]
    public class PrefabArrayReferenceDrawer : ReferenceDrawer {}
}