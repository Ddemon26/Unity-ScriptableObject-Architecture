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
using UnityEngine.Serialization;
// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to raise a UnityEvent when the game object is enabled.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Legacy/Events/UnityEvent Raiser")]
    public class UnityEventRaiser : MonoBehaviour
    {
        /// <summary>
        /// The UnityEvent that will be raised when the game object is enabled.
        /// </summary>
        [FormerlySerializedAs("OnEnableEvent")] [Tooltip("The UnityEvent that will be raised when the game object is enabled.")]
        public UnityEvent onEnableEvent;

        /// <summary>
        /// OnEnable is called when the object becomes enabled and active.
        /// It raises the OnEnableEvent.
        /// </summary>
        public void OnEnable()
        {
            onEnableEvent.Invoke();
        }
    }
}