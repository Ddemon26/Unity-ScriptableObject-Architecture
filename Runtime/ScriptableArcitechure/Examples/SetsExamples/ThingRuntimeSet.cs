using UnityEngine;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Represents a runtime set of Thing objects.
    /// This class is a ScriptableObject and can be created via the Unity editor.
    /// </summary>
    [CreateAssetMenu(menuName = "Sets/ThingRuntimeSet")]
    public class ThingRuntimeSet : RuntimeSet<Thing>
    { }
}
