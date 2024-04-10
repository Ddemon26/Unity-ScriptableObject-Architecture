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
    /// This class is used to set the value of a Slider component with the value of a FloatVariable.
    /// It executes in both edit and play modes.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/UISetters/SliderSetter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(Slider))]
    [ExecuteInEditMode]
    public class SliderSetter : MonoBehaviour
    {
        /// <summary>
        /// The Slider component whose value will be set.
        /// </summary>
        [Tooltip("The Slider component whose value will be set.")]
        [SerializeField]
        private Slider slider;

        /// <summary>
        /// The FloatVariable whose value will be used to set the Slider's value.
        /// </summary>
        [Tooltip("The FloatVariable whose value will be used to set the Slider's value.")]
        [SerializeField]
        private FloatReference variable;

        private float lastVariableValue = 0;
        private bool isSliderNotNull;

        private void Awake() => isSliderNotNull = slider != null;

        /// <summary>
        /// Validates the Slider component.
        /// </summary>
        private void OnValidate()
        {
            if (slider == null)
                slider = GetComponent<Slider>();
        }

        /// <summary>
        /// Adds a listener to the Slider's onValueChanged event.
        /// </summary>
        private void OnEnable()
        {
            if (slider != null)
            {
                slider.onValueChanged.AddListener(OnValueChange);
            }
        }

        /// <summary>
        /// Removes the listener from the Slider's onValueChanged event.
        /// </summary>
        private void OnDisable()
        {
            if (slider != null)
            {
                slider.onValueChanged.RemoveListener(OnValueChange);
            }
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the value of the Slider to the value of the FloatVariable.
        /// </summary>
        private void Update()
        {
            if (!isSliderNotNull || variable == null || Mathf.Approximately(lastVariableValue, variable)) return;
            slider.value = variable;
            lastVariableValue = variable;
        }

        /// <summary>
        /// Sets the value of the FloatVariable to the value of the Slider.
        /// </summary>
        /// <param name="value">The new value of the Slider.</param>
        public void OnValueChange(float value)
        {
            if (variable != null)
            {
                variable.SetRefValue(value);
            }
        }
    }
}