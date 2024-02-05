using UnityEngine;

namespace ScriptableArchitect.Events
{
    /// <summary>
    /// Class for an event channel that can handle float events.
    /// </summary>
    [CreateAssetMenu(menuName = "Events/FloatEventChannel")]
    public class FloatEventChannel : EventChannel<float> { }
}