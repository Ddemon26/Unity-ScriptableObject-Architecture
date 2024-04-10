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

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Takes a FloatVariable and sends its value to an Animator parameter 
    /// every frame on Update.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AnimatorSetters/Animator Parameter Setter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(Animator))]
    public class AnimatorParameterSetter : MonoBehaviour
    {
        /// <summary>
        /// Variable to read from and send to the Animator as the specified parameter.
        /// </summary>
        [Tooltip("Variable to read from and send to the Animator as the specified parameter.")]
        public FloatVariable variable;

        /// <summary>
        /// Animator to set parameters on.
        /// </summary>
        [Tooltip("Animator to set parameters on.")]
        public Animator animator;

        /// <summary>
        /// Name of the parameter to set with the value of Variable.
        /// </summary>
        [Tooltip("Name of the parameter to set with the value of Variable.")]
        public string parameterName;

        /// <summary>
        /// Animator Hash of ParameterName, automatically generated.
        /// </summary>
        [Tooltip("Animator Hash of ParameterName, automatically generated.")] [SerializeField]
        private int parameterHash;

        private float lastValue = 0;

        /// <summary>
        /// OnValidate is called when the script is loaded or a value is changed in the Inspector.
        /// It sets the parameterHash to the hash of the ParameterName.
        /// </summary>
        private void OnValidate()
        {
            if (animator == null)
                animator = GetComponent<Animator>();
            parameterHash = Animator.StringToHash(parameterName);
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the value of the Animator parameter with the hash of parameterHash to the value of the Variable.
        /// </summary>
        private void Update()
        {
            if (!(Math.Abs(variable.value - lastValue) > 0.0001f)) return;

            animator.SetFloat(parameterHash, variable.value);
            lastValue = variable.value;
        }
    }
}