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
    /// This class represents a boolean variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/BoolVariable")]
    public class BoolVariable : ValueAsset<bool>
    {
        /// <summary>
        /// Sets the value of the boolean variable to true.
        /// </summary>
        public void SetTrue() => SetValue(true);
        /// <summary>
        /// Sets the value of the boolean variable to false.
        /// </summary>
        public void SetFalse() => SetValue(false);
        /// <summary>
        /// Toggles the value of the boolean variable. If the current value is true, it will be set to false, and vice versa.
        /// </summary>
        public void Toggle() => Value = !Value;
    }
}