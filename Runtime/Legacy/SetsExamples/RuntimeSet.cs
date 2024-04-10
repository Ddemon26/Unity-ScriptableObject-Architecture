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

using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Represents a runtime set of generic type T.
    /// This class is a ScriptableObject and can be created via the Unity editor.
    /// </summary>
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        /// <summary>
        /// List of items of type T.
        /// </summary>
        public List<T> items = new List<T>();

        /// <summary>
        /// Adds an item to the set.
        /// </summary>
        /// <param name="thing">The item to add.</param>
        public void Add(T thing)
        {
            if (!items.Contains(thing))
                items.Add(thing);
        }

        /// <summary>
        /// Removes an item from the set.
        /// </summary>
        /// <param name="thing">The item to remove.</param>
        public void Remove(T thing)
        {
            if (items.Contains(thing))
                items.Remove(thing);
        }
    }
}