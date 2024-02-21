using System.Collections.Generic;
using UnityEngine;

namespace ScriptableArchitect.Events
{
    /// <summary>
    /// Abstract class for an event channel that can handle events of a specific type.
    /// </summary>
    /// <typeparam name="T">The type of event that the channel can handle.</typeparam>
    public abstract class EventChannel<T> : ScriptableObject
    {
        /// <summary>
        /// A set of observers that are listening for events on this channel.
        /// </summary>
        readonly HashSet<EventListener<T>> observers = new();

        /// <summary>
        /// Invokes the event on all registered observers.
        /// </summary>
        /// <param name="value">The event to invoke.</param>
        public void Invoke(T value)
        {
            foreach (var observer in observers)
            {
                observer.Raise(value);
            }
        }

        /// <summary>
        /// Registers an observer to listen for events on this channel.
        /// </summary>
        /// <param name="observer">The observer to register.</param>
        public void Register(EventListener<T> observer) => observers.Add(observer);

        /// <summary>
        /// Deregisters an observer from listening for events on this channel.
        /// </summary>
        /// <param name="observer">The observer to deregister.</param>
        public void Deregister(EventListener<T> observer) => observers.Remove(observer);
    }

    /// <summary>
    /// Struct for an empty event.
    /// </summary>
    public readonly struct Empty { }

    /// <summary>
    /// Class for an event channel that can handle empty events.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Events/EventChannel")]
    public class EventChannel : EventChannel<Empty> { }
}
