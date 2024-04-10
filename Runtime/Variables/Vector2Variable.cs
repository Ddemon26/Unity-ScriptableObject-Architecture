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
    /// This class represents a Vector2 variable that can be created as a ScriptableObject.
    /// Inherits from the <see cref="ValueAsset{T}"/> class with <see cref="Vector2"/> as the type parameter.
    /// </summary>
    /// <remarks>
    /// This class is used to create a Vector2 variable that can be saved as a ScriptableObject in Unity.
    /// This allows for easy management and reuse of Vector2 values across different scripts and scenes.
    /// </remarks>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Vectors/Vector2Variable")]
    public class Vector2Variable : ValueAsset<Vector2>
    {
        /// <summary>
        /// Applies a change to the value of the Vector2 variable.
        /// </summary>
        /// <param name="amount">The amount to change the value by.</param>
        /// <remarks>
        /// This method adds the provided amount to the current value of the Vector2 variable.
        /// The result is then set as the new value of the Vector2 variable.
        /// </remarks>
        public void ApplyChange(Vector2 amount)
        {
            SetValue(value += amount);
        }

        /// <summary>
        /// Applies a change to the value of the Vector2 variable from another Vector2Variable.
        /// </summary>
        /// <param name="amount">The Vector2Variable to get the change amount from.</param>
        /// <remarks>
        /// This method adds the value of the provided Vector2Variable to the current value of the Vector2 variable.
        /// The result is then set as the new value of the Vector2 variable.
        /// </remarks>
        public void ApplyChange(Vector2Variable amount)
        {
            SetValue(value += amount.value);
        }
    }
}