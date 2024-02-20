using UnityEngine;
using UnityEngine.Events;

namespace ScriptableArchitect.Events
{
    /// <summary>
    /// Abstract class for an event listener that can handle events of a specific type.
    /// </summary>
    /// <typeparam name="T">The type of event that the listener can handle.</typeparam>
    public abstract class EventListener<T> : MonoBehaviour
    {
        /// <summary>
        /// The event channel that the listener is subscribed to.
        /// </summary>
        [Tooltip("The event channel that the listener is subscribed to.")]
        [SerializeField] EventChannel<T> eventChannel;

        /// <summary>
        /// The Unity event to invoke when the event is raised.
        /// </summary>
        [Tooltip("The Unity event to invoke when the event is raised.")]
        [SerializeField] UnityEvent<T> unityEvent;

        /// <summary>
        /// Registers the listener with the event channel when the object is awakened.
        /// </summary>
        protected void Awake()
        {
            eventChannel.Register(this);
        }

        /// <summary>
        /// Deregisters the listener from the event channel when the object is destroyed.
        /// </summary>
        protected void OnDestroy()
        {
            eventChannel.Deregister(this);
        }

        /// <summary>
        /// Raises the event, invoking the Unity event with the given value.
        /// </summary>
        /// <param name="value">The value to pass to the Unity event.</param>
        public void Raise(T value)
        {
            unityEvent?.Invoke(value);
        }
    }

    /// <summary>
    /// Class for an event listener that can handle empty events.
    /// </summary>
    [Tooltip("Class for an event listener that can handle empty events.")]
    public class EventListener : EventListener<Empty> { }
}