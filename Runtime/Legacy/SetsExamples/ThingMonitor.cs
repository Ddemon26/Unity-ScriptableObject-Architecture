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
using TMPro;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// This class is used to monitor the count of items in a ThingRuntimeSet and display it in a TextMeshProUGUI component.
    /// </summary>
    [System.Obsolete("This class is obsolete. Use the 'ThingMonitor' class from the 'YourMom' namespace instead.")]
    public class ThingMonitor : MonoBehaviour
    {
        /// <summary>
        /// The ThingRuntimeSet whose items count will be monitored.
        /// </summary>
        [Tooltip("The runtime set of 'Thing' objects to monitor.")]
        public ThingRuntimeSet set;

        /// <summary>
        /// The TextMeshProUGUI component where the items count will be displayed.
        /// </summary>
        [Tooltip("The TextMeshProUGUI component to display the items count.")]
        public TMP_Text textComponent;

        /// <summary>
        /// The previous count of items. Used to check if the count has changed.
        /// </summary>
        private int previousCount = -1;

        /// <summary>
        /// OnEnable is called when the object becomes enabled and active.
        /// It updates the text of the TextMeshProUGUI component.
        /// </summary>
        private void OnEnable()
        {
            UpdateText();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// If the count of items has changed, it updates the text of the TextMeshProUGUI component.
        /// </summary>
        private void Update()
        {
            if (previousCount != set.items.Count)
            {
                UpdateText();
                previousCount = set.items.Count;
            }
        }

        /// <summary>
        /// Updates the text of the TextMeshProUGUI component to display the current count of items.
        /// </summary>
        public void UpdateText()
        {
            textComponent.text = "There are " + set.items.Count + " things.";
        }
    }
}