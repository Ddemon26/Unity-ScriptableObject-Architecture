using UnityEngine;

namespace ScriptableArchitect.Events
{
    /// <summary>
    /// Class for an event channel that can handle integer events.
    /// </summary>
    [CreateAssetMenu(menuName = "Events/IntEventChannel")]
    public class IntEventChannel : EventChannel<int> { }
}