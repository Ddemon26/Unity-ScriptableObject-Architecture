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
    /// This class is used to move a game object using keyboard input.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Legacy/Input/Keyboard Mover")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class KeyboardMover : MonoBehaviour
    {
        /// <summary>
        /// This class represents an axis of movement, with positive and negative directions corresponding to different keys.
        /// </summary>
        [Serializable]
        public class MoveAxis
        {
            /// <summary>
            /// The key that corresponds to positive movement along the axis.
            /// </summary>
            [Tooltip("The key that corresponds to positive movement along the axis.")]
            public KeyCode positive;
            /// <summary>
            /// The key that corresponds to negative movement along the axis.
            /// </summary>
            [Tooltip("The key that corresponds to negative movement along the axis.")]
            public KeyCode negative;

            public MoveAxis(KeyCode positive, KeyCode negative)
            {
                this.positive = positive;
                this.negative = negative;
            }
            /// <summary>
            /// Converts the MoveAxis to a float representing the current movement along the axis.
            /// Positive if the Positive key is pressed, negative if the Negative key is pressed, and zero otherwise.
            /// </summary>
            public static implicit operator float(MoveAxis axis)
            {
                return (Input.GetKey(axis.positive)
                    ? 1.0f : 0.0f) -
                    (Input.GetKey(axis.negative)
                    ? 1.0f : 0.0f);
            }
        }
        /// <summary>
        /// The rate of movement.
        /// </summary>
        [Tooltip("The rate of movement.")]
        public FloatVariable moveRate;

        /// <summary>
        /// The horizontal axis of movement.
        /// </summary>
        [Tooltip("The horizontal axis of movement.")]
        public MoveAxis horizontal = new MoveAxis(KeyCode.D, KeyCode.A);

        /// <summary>
        /// The vertical axis of movement.
        /// </summary>
        [Tooltip("The vertical axis of movement.")]
        public MoveAxis vertical = new MoveAxis(KeyCode.W, KeyCode.S);

        /// <summary>
        /// Update is called once per frame.
        /// It moves the game object according to the input from the horizontal and vertical axes.
        /// </summary>
        private void Update()
        {
            var moveNormal = new Vector3(horizontal, vertical, 0.0f).normalized;

            transform.position += moveNormal * (Time.deltaTime * moveRate.value);
        }
    }
}