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
    /// This class represents a Quaternion variable that can be created as a ScriptableObject.
    /// Inherits from the <see cref="ValueAsset{T}"/> class with <see cref="Quaternion"/> as the type parameter.
    /// </summary>
    /// <remarks>
    /// This class is used to create a Quaternion variable that can be saved as a ScriptableObject in Unity.
    /// This allows for easy management and reuse of Quaternion values across different scripts and scenes.
    /// </remarks>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/QuaternionVariable")]
    public class QuaternionVariable : ValueAsset<Quaternion>
    {
        /// <summary>
        /// Applies a change to the value of the Quaternion variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        /// <remarks>
        /// This method multiplies the current value of the Quaternion variable by the provided amount.
        /// The result is then set as the new value of the Quaternion variable.
        /// </remarks>
        public void ApplyChange(Quaternion amount)
        {
            SetValue(value *= amount);
        }

        /// <summary>
        /// Applies a change to the value of the Quaternion variable from another QuaternionVariable.
        /// </summary>
        /// <param name="amount">The QuaternionVariable to get the change amount from.</param>
        /// <remarks>
        /// This method multiplies the current value of the Quaternion variable by the value of the provided QuaternionVariable.
        /// The result is then set as the new value of the Quaternion variable.
        /// </remarks>
        public void ApplyChange(QuaternionVariable amount)
        {
            SetValue(value *= amount.value);
        }
    }
}