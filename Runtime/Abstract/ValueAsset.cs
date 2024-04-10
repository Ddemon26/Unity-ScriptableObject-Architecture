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
namespace ScriptableArchitect
{
    /// <summary>
    /// This abstract class represents a variable of a specific type that can be created as a ScriptableObject.
    /// </summary>
    /// <typeparam name="T">The type of the variable.</typeparam>
    /// <remarks>
    /// This class is used to create a variable of a specific type that can be saved as a ScriptableObject in Unity.
    /// This allows for easy management and reuse of variable values across different scripts and scenes.
    /// </remarks>
    public abstract class ValueAsset<T> : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        [Multiline] [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string developerDescription = "";
#endif
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public T value;

        /// <summary>
        /// Property to get or set the value of the variable.
        /// </summary>
        public T Value
        {
            get => value;
            set => this.value = value;
        }

        /// <summary>
        /// Sets the value of the variable.
        /// </summary>
        /// <param name="refValue">The new value for the variable.</param>
        public virtual void SetValue(T refValue) => Value = refValue;

        /// <summary>
        /// Sets the value of the variable to the value of another ValueAsset.
        /// </summary>
        /// <param name="refValue">The ValueAsset whose value will be used.</param>
        public virtual void SetValue(ValueAsset<T> refValue) => Value = refValue.Value;

        /// <summary>
        /// Implicit conversion operator from ValueAsset to T.
        /// </summary>
        /// <param name="asset">The ValueAsset to convert.</param>
        public static implicit operator T(ValueAsset<T> asset) => asset.Value;
    }
}