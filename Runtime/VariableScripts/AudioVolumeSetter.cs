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
    /// This class is used to set the volume of an AudioMixer based on the value of a FloatVariable.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/AudioVolumeSetter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class AudioVolumeSetter : MonoBehaviour
    {
        /// <summary>
        /// The AudioMixer whose volume will be set.
        /// </summary>
        [Tooltip("The AudioMixer whose volume will be set.")]
        public AudioMixer mixer;

        /// <summary>
        /// The name of the volume parameter in the AudioMixer.
        /// </summary>
        [Tooltip("The name of the volume parameter in the AudioMixer.")]
        public string parameterName = "";

        /// <summary>
        /// The FloatVariable that represents the volume. Its value should be between 0.0 (silent) and 1.0 (full volume).
        /// </summary>
        [Tooltip(
            "The FloatVariable that represents the volume. Its value should be between 0.0 (silent) and 1.0 (full volume).")]
        public FloatVariable variable;

        private float lastValue = 0;

        private void Awake()
        {
            if (mixer == null)
            {
                Debug.LogError("AudioMixer is not set in the AudioVolumeSetter component.");
                return;
            }

            if (string.IsNullOrEmpty(parameterName))
            {
                Debug.LogError("ParameterName is not set in the AudioVolumeSetter component.");
                return;
            }

            if (variable == null)
            {
                Debug.LogError("FloatVariable is not set in the AudioVolumeSetter component.");
                return;
            }

            SetVolume(variable.value);
        }

        private void SetVolume(float volume)
        {
            mixer.SetFloat(parameterName, volume);
            lastValue = volume;
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the volume of the AudioMixer to the value of the FloatVariable, converted to decibels.
        /// </summary>
        private void Update()
        {
            if (!(Math.Abs(variable.value - lastValue) > 0.0001f)) return;

            var dB = variable.value > 0.0f ? 20.0f * Mathf.Log10(variable.value) : -80.0f;

            mixer.SetFloat(parameterName, dB);
            lastValue = variable.value;
        }
    }
}