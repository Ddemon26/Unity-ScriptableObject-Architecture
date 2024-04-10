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
using System;
using UnityEngine;
using UnityEngine.Audio;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Takes a FloatVariable and sends a curve filtered version of its value 
    /// to an exposed audio mixer parameter every frame on Update.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/Audio Parameter Setter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class AudioParameterSetter : MonoBehaviour
    {
        /// <summary>
        /// Mixer to set the parameter in.
        /// </summary>
        [Tooltip("Mixer to set the parameter in.")]
        public AudioMixer mixer;

        /// <summary>
        /// Name of the parameter to set in the mixer.
        /// </summary>
        [Tooltip("Name of the parameter to set in the mixer.")]
        public string parameterName = "";

        /// <summary>
        /// Variable to send to the mixer parameter.
        /// </summary>
        [Tooltip("Variable to send to the mixer parameter.")]
        public FloatVariable variable;

        /// <summary>
        /// Minimum value of the Variable that is mapped to the curve.
        /// </summary>
        [Tooltip("Minimum value of the Variable that is mapped to the curve.")]
        public FloatReference min;

        /// <summary>
        /// Maximum value of the Variable that is mapped to the curve.
        /// </summary>
        [Tooltip("Maximum value of the Variable that is mapped to the curve.")]
        public FloatReference max;

        /// <summary>
        /// Curve to evaluate in order to look up a final value to send as the parameter.
        /// T=0 is when Variable == Min
        /// T=1 is when Variable == Max
        /// </summary>
        [Tooltip("Curve to evaluate in order to look up a final value to send as the parameter.\n" +
                 "T=0 is when Variable == Min\n" +
                 "T=1 is when Variable == Max")]
        public AnimationCurve curve;

        private float lastValue;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake() => lastValue = variable.value;

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It calculates a value based on the Variable, Min, Max, and Curve, and sets the ParameterName parameter of the Mixer to this value.
        /// </summary>
        private void Update()
        {
            if (!(Math.Abs(variable.value - lastValue) > 0.0001f)) return;
            
            var t = Mathf.InverseLerp(min.Value, max.Value, variable.value);
            var value = curve.Evaluate(Mathf.Clamp01(t));
            mixer.SetFloat(parameterName, value);
            lastValue = variable.value;
        }
    }
}