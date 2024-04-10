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

using ScriptableArchitect.Variables;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Editor
{
    /// <summary>
    /// Custom editor for FloatVariable objects.
    /// </summary>
    /// <remarks>
    /// This class inherits from the <see cref="UnityEditor.Editor"/> class and is used to create a custom editor for FloatVariable objects.
    /// The [CustomEditor(typeof(FloatVariable))] attribute indicates that this editor is used for FloatVariable objects.
    /// </remarks>
    /// <seealso cref="UnityEditor.Editor"/>
    [CustomEditor(typeof(FloatVariable))]
    public class FloatVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Overrides the OnInspectorGUI method of the UnityEditor.Editor class.
        /// </summary>
        /// <remarks>
        /// This method is called to draw the inspector window of the FloatVariable object.
        /// It first calls the base implementation of the method, then checks if the useMinMaxSlider property of the FloatVariable object is true.
        /// If it is, it creates a slider in the inspector that allows the user to change the value of the FloatVariable object within its min and max values.
        /// </remarks>
        public override void OnInspectorGUI()
        {
            // Call the base implementation of OnInspectorGUI to draw the default inspector
            base.OnInspectorGUI();

            // Get a reference to the FloatVariable object
            var script = (FloatVariable)target;

            // If the useMinMaxSlider property of the FloatVariable object is true, create a slider in the inspector
            if (!script.useMinMaxSlider) return;
            // Begin a change check block
            EditorGUI.BeginChangeCheck();

            // Create a slider in the inspector that allows the user to change the value of the FloatVariable object within its min and max values
            var newValue = EditorGUILayout.Slider("Value", script.value, script.minValue, script.maxValue);

            // If the value of the slider has changed, update the value of the FloatVariable object
            if (EditorGUI.EndChangeCheck())
            {
                script.SetValue(newValue);
            }
        }
    }
}