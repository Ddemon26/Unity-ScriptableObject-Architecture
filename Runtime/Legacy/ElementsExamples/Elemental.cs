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
namespace ScriptableArchitect.Elements
{
    /// <summary>
    /// This class represents an elemental entity in the game.
    /// </summary>
    [System.Obsolete("This class is part of the legacy system and is obsolete.")]
    [AddComponentMenu("Scriptable Architect/Variables/Examples/Elemental")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class Elemental : MonoBehaviour
    {
        /// <summary>
        /// The element represented by this elemental.
        /// </summary>
        [Tooltip("Element represented by this elemental.")]
        public AttackElement element;

        /// <summary>
        /// The text component to display the name of the element.
        /// </summary>
        [Tooltip("Text to fill in with the element name.")]
        public TMP_Text componentLabel;

        /// <summary>
        /// This method is called when the script instance is being loaded.
        /// It sets the text of the Label to the name of the Element.
        /// </summary>
        private void OnEnable()
        {
            if (componentLabel != null && element != null)
                componentLabel.text = element.name;
        }

        /// <summary>
        /// This method is called when the Collider other enters the trigger.
        /// It checks if the other collider also has an Elemental component and if its Element is in the defeated elements of this Elemental's Element.
        /// If so, it destroys this game object.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Elemental e) && e.element != null &&
                e.element.defeatedElements.Contains(element))
            {
                Destroy(gameObject);
            }
        }
    }
}