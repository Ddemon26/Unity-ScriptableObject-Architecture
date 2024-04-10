// ----------------------------------------------------------------------------
// Created by: TentCity Software
// Author: Damon Fedorick
// Date: 01/01/2024
// Version: 1.0.1
// 
// Copyright (c) 2023 TentCity Software. All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// ----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Events;
// ReSharper disable once CheckNamespace
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
        [SerializeField]
        private EventChannel<T> eventChannel;

        /// <summary>
        /// The Unity event to invoke when the event is raised.
        /// </summary>
        [Tooltip("The Unity event to invoke when the event is raised.")]
        [SerializeField]
        private UnityEvent<T> unityEvent;

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
    [AddComponentMenu("Scriptable Architect/Events/Event Listener")]
    [HelpURL("https://www.youtube.com/watch?v=h8ZAOWY_5LA&t=976s")]
    [Tooltip("Class for an event listener that can handle empty events.")]
    public class EventListener : EventListener<Empty> { }
}