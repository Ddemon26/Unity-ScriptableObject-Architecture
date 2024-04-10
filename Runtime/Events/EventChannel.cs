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
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable once CheckNamespace
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
        private readonly HashSet<EventListener<T>> observers = new();

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
