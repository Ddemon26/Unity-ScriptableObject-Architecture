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
// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// A MonoBehaviour that triggers an AudioSource when a FloatVariable falls below a certain threshold.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/Variable Audio Trigger")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class VariableAudioTrigger : MonoBehaviour
    {
        /// <summary>
        /// The AudioSource that will be triggered when the FloatVariable falls below the lowThreshold.
        /// </summary>
        [Tooltip("The AudioSource that will be triggered.")]
        public AudioSource audioSource;

        /// <summary>
        /// The FloatVariable that will be monitored. When its value falls below lowThreshold, the AudioSource is triggered.
        /// </summary>
        [Tooltip("The FloatVariable that will be monitored.")]
        public FloatVariable variable;

        /// <summary>
        /// The threshold below which the AudioSource will be triggered. If the FloatVariable's value falls below this threshold, the AudioSource is triggered.
        /// </summary>
        [Tooltip("The threshold below which the AudioSource will be triggered.")]
        public FloatReference lowThreshold;

        /// <summary>
        /// A boolean flag indicating whether the AudioSource is currently playing.
        /// </summary>
        private bool isPlaying;

        /// <summary>
        /// Monitors the FloatVariable's value every frame. If the value falls below lowThreshold and the AudioSource is not already playing, it triggers the AudioSource. If the value is above lowThreshold and the AudioSource is playing, it stops the AudioSource.
        /// </summary>
        private void Update()
        {
            if (variable < lowThreshold)
            {
                if (isPlaying) return;
                audioSource.Play();
                isPlaying = true;
            }
            else
            {
                if (!isPlaying) return;
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}