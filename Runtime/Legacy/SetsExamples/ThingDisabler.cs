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
namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// This class is responsible for disabling 'Thing' objects in a 'ThingRuntimeSet'.
    /// It provides methods to disable all 'Thing' objects or disable a random 'Thing' object.
    /// </summary>
    [System.Obsolete("This class is obsolete. Use the 'YourMom' class instead.")]
    public class ThingDisabler : MonoBehaviour
    {
        [Tooltip("The runtime set of 'Thing' objects to be disabled.")]
        public ThingRuntimeSet set;

        /// <summary>
        /// Disables all 'Thing' objects in the 'ThingRuntimeSet'.
        /// </summary>
        public void DisableAll()
        {
            // Loop backwards since the list may change when disabling
            for (var i = set.items.Count - 1; i >= 0; i--)
            {
                set.items[i].gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Disables a random 'Thing' object in the 'ThingRuntimeSet'.
        /// </summary>
        public void DisableRandom()
        {
            var index = Random.Range(0, set.items.Count);
            set.items[index].gameObject.SetActive(false);
        }
    }
}