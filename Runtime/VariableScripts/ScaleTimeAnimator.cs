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
using UnityEngine.Serialization;
// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Controls the speed of an Animator based on a Boolean variable.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AnimatorSetters/ScaleTimeAnimator", 1)]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(Animator))]
    public class ScaleTimeAnimator : MonoBehaviour
    {
        /// <summary>
        /// The Animator whose speed is to be controlled.
        /// </summary>
        [FormerlySerializedAs("Animator")]
        [Tooltip("The Animator whose speed is to be controlled.")]
        [SerializeField]
        private Animator animator;

        /// <summary>
        /// The Boolean variable that determines whether the Animator should be stopped or not.
        /// </summary>
        [Tooltip("The Boolean variable that determines whether the Animator should be stopped or not.")]
        [SerializeField]
        private BoolVariable stopAnimator;

        /// <summary>
        /// If set to true, the Animator will be stopped when stopAnimator is false and vice versa.
        /// </summary>
        [Tooltip("If set to true, the Animator will be stopped when stopAnimator is false and vice versa.")]
        [SerializeField]
        private bool invertSetting;

        /// <summary>
        /// Validates the Animator component.
        /// </summary>
        private void OnValidate()
        {
            if (animator == null)
                animator = GetComponent<Animator>();
        }
        /// <summary>
        /// Updates the Animator speed based on the stopAnimator value and invertSetting.
        /// </summary>
        private void Update()
        {
            animator.speed = (stopAnimator.Value ^ invertSetting) ? 1 : 0;
        }
    }
}