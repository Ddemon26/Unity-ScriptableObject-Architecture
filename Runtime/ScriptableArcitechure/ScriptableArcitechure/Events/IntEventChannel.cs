using UnityEngine;

namespace ScriptableArchitect.Events
{
    /// <summary>
    /// Class for an event channel that can handle integer events.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Events/IntEventChannel")]
    public class IntEventChannel : EventChannel<int> { }
}