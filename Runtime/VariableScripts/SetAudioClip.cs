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
using ScriptableArchitect.Variables;
using UnityEngine;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Sets an AudioClip to an AudioSource and controls its playback.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/SetAudioClip")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(AudioSource))]
    public class SetAudioClip : MonoBehaviour
    {
        /// <summary>
        /// The AudioSource to which the AudioClip will be set.
        /// </summary>
        [Tooltip("The AudioSource to which the AudioClip will be set.")]
        [SerializeField]
        private AudioSource audioSource;

        /// <summary>
        /// Reference to the AudioClip to be set.
        /// </summary>
        [Tooltip("Reference to the AudioClip to be set.")]
        [SerializeField]
        private AudioClipReference audioClipRef;

        /// <summary>
        /// If true, the AudioClip will be set and played on Awake.
        /// </summary>
        [Tooltip("If true, the AudioClip will be set and played on Awake.")]
        [SerializeField]
        private bool playOnAwake;

        /// <summary>
        /// If true, the AudioClip will be updated every frame.
        /// </summary>
        [Tooltip("If true, the AudioClip will be updated every frame.")]
        [SerializeField]
        private bool alwaysUpdate;

        private void OnValidate()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }
        private void Awake()
        {
            if (playOnAwake)
            {
                SetClipAndPlay();
            }
        }

        private void Update()
        {
            if (alwaysUpdate && audioSource.clip != audioClipRef.Value)
            {
                SetClipAndPlay();
            }
        }

        /// <summary>
        /// Sets the AudioClip to the AudioSource and plays it if it's not already playing.
        /// </summary>
        private void SetClipAndPlay()
        {
            audioSource.clip = audioClipRef.Value;
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
    }
}