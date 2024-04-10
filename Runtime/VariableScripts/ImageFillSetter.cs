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
using UnityEngine.UI;
// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Sets an Image component's fill amount to represent how far Variable is
    /// between Min and Max.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/UISetters/ImageFillSetter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(Image))]
    public class ImageFillSetter : MonoBehaviour
    {
        /// <summary>
        /// The variable to use as the current value.
        /// </summary>
        [Tooltip("Value to use as the current ")]
        public FloatReference variable;

        /// <summary>
        /// The minimum value that Variable can have for the Image to have no fill.
        /// </summary>
        [Tooltip("Min value that Variable to have no fill on Image.")]
        public FloatReference min;

        /// <summary>
        /// The maximum value that Variable can be for the Image to be filled.
        /// </summary>
        [Tooltip("Max value that Variable can be to fill Image.")]
        public FloatReference max;

        /// <summary>
        /// The Image to set the fill amount on.
        /// </summary>
        [Tooltip("Image to set the fill amount on.")]
        public Image image;

        private float lastVariableValue = 0;

        /// <summary>
        /// Validates the Image component.
        /// </summary>
        private void OnValidate()
        {
            if (image == null)
                image = GetComponent<Image>();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the fill amount of the Image to represent how far Variable is between Min and Max.
        /// </summary>
        private void Update()
        {
            if (Mathf.Approximately(lastVariableValue, variable.Value)) return;

            image.fillAmount = Mathf.Clamp01(
                Mathf.InverseLerp(min, max, variable));
            lastVariableValue = variable.Value;
        }
    }
}