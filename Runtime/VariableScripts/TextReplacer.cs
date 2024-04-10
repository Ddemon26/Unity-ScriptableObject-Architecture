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
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to replace the text of a TextMeshProUGUI component with the value of a StringVariable.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/UISetters/Text Replacer")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class TextReplacer : MonoBehaviour
    {
        /// <summary>
        /// The TextMeshProUGUI component whose text will be replaced.
        /// </summary>
        [Tooltip("The TextMeshProUGUI component whose text will be replaced.")]
        public TMP_Text textComponent;

        /// <summary>
        /// The StringVariable whose value will be used to replace the text.
        /// </summary>
        [Tooltip("The StringVariable whose value will be used to replace the text.")]
        public StringVariable variable;

        /// <summary>
        /// If set to true, the text will be updated every frame.
        /// </summary>
        [Tooltip("If set to true, the text will be updated every frame.")]
        public bool alwaysUpdate;

        private string lastValue = "";
        private bool isVariableNotNull;
        private bool isTextComponentNotNull;

        /// <summary>
        /// Validates the TextMeshProUGUI component. Editor only.
        /// </summary>
        private void OnValidate()
        {
            if (textComponent == null)
                textComponent = GetComponent<TMP_Text>();
        }

        /// <summary>
        /// OnEnable is called when the object becomes enabled and active.
        /// It updates the text of the TextMeshProUGUI component.
        /// </summary>
        private void OnEnable()
        {
            UpdateText();
        }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// We update the text of the TextMeshProUGUI component.
        /// </summary>
        private void Awake()
        {
            isTextComponentNotNull = textComponent != null;
            isVariableNotNull = variable != null;
            UpdateText();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// If AlwaysUpdate is true, it updates the text of the TextMeshProUGUI component.
        /// </summary>
        private void Update()
        {
            if (alwaysUpdate && variable.Value != lastValue)
            {
                UpdateText();
            }
        }

        /// <summary>
        /// Updates the text of the TextMeshProUGUI component to the value of the StringVariable.
        /// </summary>
        private void UpdateText()
        {
            if (!isVariableNotNull || !isTextComponentNotNull) return;
            
            textComponent.text = variable.Value;
            lastValue = variable.Value;
        }
    }
}