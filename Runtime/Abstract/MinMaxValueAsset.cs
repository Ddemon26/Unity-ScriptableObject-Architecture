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
    /// This abstract class represents a variable of a specific type that can be created as a ScriptableObject.
    /// The variable's value can be optionally clamped between a minimum and maximum value.
    /// Inherits from the <see cref="ValueAsset{T}"/> class with <see cref="T"/> as the type parameter.
    /// </summary>
    /// <typeparam name="T">The type of the variable. Must implement <see cref="System.IComparable{T}"/>.</typeparam>
    /// <remarks>
    /// This class is used to create a variable of a specific type that can be saved as a ScriptableObject in Unity.
    /// This allows for easy management and reuse of variable values across different scripts and scenes.
    /// </remarks>
    public abstract class MinMaxValueAsset<T> : ValueAsset<T> where T : System.IComparable<T>
    {
        /// <summary>
        /// If true, the value of the variable will be clamped between the MinValue and MaxValue.
        /// </summary>
        [Tooltip("If true, the value of the variable will be clamped between the MinValue and MaxValue.")]
        public bool useMinMaxSlider;
        
        /// <summary>
        /// The minimum value of the variable.
        /// </summary>
        [Tooltip("The minimum value of the variable.")] [ConditionalHide("useMinMaxSlider")]
        public T minValue;
        
        /// <summary>
        /// The maximum value of the variable.
        /// </summary>
        [Tooltip("The maximum value of the variable.")] [ConditionalHide("useMinMaxSlider")]
        public T maxValue;
        
        /// <summary>
        /// Sets the value of the variable.
        /// If useMinMaxSlider is true, the value will be clamped between the MinValue and MaxValue.
        /// </summary>
        /// <param name="refValue">The new value for the variable.</param>
        public override void SetValue(T refValue)
        {
            if (useMinMaxSlider)
            {
                if (refValue.CompareTo(minValue) < 0)
                {
                    Value = minValue;
                }
                else if (refValue.CompareTo(maxValue) > 0)
                {
                    Value = maxValue;
                }
                else
                {
                    Value = refValue;
                }
            }
            else
            {
                Value = refValue;
            }
        }
        
        /// <summary>
        /// Sets the value of the variable to the value of another ValueAsset.
        /// If useMinMaxSlider is true, the value will be clamped between the MinValue and MaxValue.
        /// </summary>
        /// <param name="refValue">The ValueAsset whose value will be used.</param>
        public override void SetValue(ValueAsset<T> refValue)
        {
            if (useMinMaxSlider)
            {
                if (refValue.Value.CompareTo(minValue) < 0)
                {
                    Value = minValue;
                }
                else if (refValue.Value.CompareTo(maxValue) > 0)
                {
                    Value = maxValue;
                }
                else
                {
                    Value = refValue.Value;
                }
            }
            else
            {
                Value = refValue.Value;
            }
        }
    }
}