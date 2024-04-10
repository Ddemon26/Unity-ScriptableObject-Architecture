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
using ScriptableArchitect.Variables;
using UnityEngine;
// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Sets the volume of an AudioSource based on a FloatReference.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/SetVolumeRef")]
    [RequireComponent(typeof(AudioSource))]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class SetVolumeRef : MonoBehaviour
    {
        /// <summary>
        /// The AudioSource whose volume will be set.
        /// </summary>
        [Tooltip("The AudioSource whose volume will be set.")]
        [SerializeField]
        private AudioSource audioSource;

        /// <summary>
        /// Reference to the FloatReference that controls the volume.
        /// </summary>
        [Tooltip("Reference to the FloatReference that controls the volume.")]
        [SerializeField]
        private FloatReference volumeRef;

        /// <summary>
        /// Multiplier for the volume value.
        /// </summary>
        [Tooltip("Multiplier for the volume value.")]
        [SerializeField]
        private float volumeMultiplier = 1;

        /// <summary>
        /// The last volume value, used to check if the volume has changed.
        /// </summary>
        private float lastVolume = 1;

        /// <summary>
        /// Validates the AudioSource component.
        /// </summary>
        private void OnValidate()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// when the script calls start, it sets the volume of the AudioSource to the value of the FloatReference.
        /// </summary>
        private void Start()
        {
            audioSource.volume = volumeRef.Value * volumeMultiplier;
            lastVolume = volumeRef.Value;
        }
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the volume of the AudioSource to the value of the FloatReference.
        /// </summary>
        private void Update()
        {
            if (!(Math.Abs(volumeRef.Value - lastVolume) > 0.0001f)) return;
            
            audioSource.volume = volumeRef.Value * volumeMultiplier;
            lastVolume = volumeRef.Value;
        }
    }
}