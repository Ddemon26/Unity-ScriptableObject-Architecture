using UnityEditor;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Custom drawer for the AnimatorReference.
    /// </summary>
    [CustomPropertyDrawer(typeof(AnimatorReference))]
    public class AnimatorReferenceDrawer : ReferenceDrawer { }
}