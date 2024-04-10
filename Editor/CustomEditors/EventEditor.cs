// ----------------------------------------------------------------------------
// Created by: TentCity Software
// Author: Damon Fedorick
// Date: 1/01/2024
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

using ScriptableArchitect.Events;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Editor
{
    /// <summary>
    /// Custom editor for EventChannel objects.
    /// </summary>
    /// <remarks>
    /// This class inherits from the <see cref="UnityEditor.Editor"/> class and is used to create a custom editor for EventChannel objects.
    /// The [CustomEditor(typeof(EventChannel), true)] attribute indicates that this editor is used for EventChannel objects.
    /// </remarks>
    /// <seealso cref="UnityEditor.Editor"/>
    [CustomEditor(typeof(EventChannel), true)]
    public class EventEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Overrides the OnInspectorGUI method of the UnityEditor.Editor class.
        /// </summary>
        /// <remarks>
        /// This method is called to draw the inspector window of the EventChannel object.
        /// It first calls the base implementation of the method, then adds a "Raise" button that, when clicked, invokes an empty event on the EventChannel object.
        /// </remarks>
        public override void OnInspectorGUI()
        {
            // Call the base implementation of OnInspectorGUI to draw the default inspector
            base.OnInspectorGUI();

            // Add a "Raise" button to the inspector
            if (GUILayout.Button("Raise"))
            {
                // When the "Raise" button is clicked, invoke an empty event on the EventChannel object
                ((EventChannel)target).Invoke(new Empty());
            }
        }
    }
}