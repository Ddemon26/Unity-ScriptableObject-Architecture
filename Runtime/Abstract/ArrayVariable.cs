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
    /// This abstract class represents an array variable of a specific type that can be created as a ScriptableObject.
    /// Inherits from the <see cref="ValueAsset{T}"/> class with <see cref="T"/> as the type parameter.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <remarks>
    /// This class is used to create an array variable of a specific type that can be saved as a ScriptableObject in Unity.
    /// This allows for easy management and reuse of array values across different scripts and scenes.
    /// </remarks>
    public abstract class ArrayVariable<T> : ValueAsset<T[]>
    {
        /// <summary>
        /// Retrieves the value at the specified index in the array.
        /// </summary>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <returns>The element at the specified index in the array.</returns>
        /// <remarks>
        /// If the index is out of range, a warning is logged and the first element in the array is returned.
        /// This method is part of the <see cref="ArrayVariable{T}"/> class, which inherits from the <see cref="ValueAsset{T}"/> class.
        /// </remarks>
        public T GetValue(int index)
        {
            if (index >= 0 && index < value.Length) return value[index];
            Debug.LogWarning("Index out of range, returning first element in array.");
            return value[0];
        }
    }
}