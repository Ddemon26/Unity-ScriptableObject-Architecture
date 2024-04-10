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
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to set the value of a FloatVariable based on the input from a TMP_InputField.
    /// It executes in both edit and play modes.
    /// </summary>
    /// <remarks>
    /// This class is responsible for synchronizing the value of a FloatVariable with the text input from a TMP_InputField.
    /// It listens to the onSelect, onDeselect, and onEndEdit events of the TMP_InputField.
    /// When the TMP_InputField is not selected, it updates the text of the TMP_InputField to match the value of the FloatVariable.
    /// When the text of the TMP_InputField is edited, it attempts to parse the new text as a float and set the value of the FloatVariable to the parsed value.
    /// </remarks>
    [AddComponentMenu("Scriptable Architect/Variables/UISetters/InputFieldSetter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(TMP_InputField))]
    [ExecuteInEditMode]
    public class InputFieldSetter : MonoBehaviour
    {
        /// <summary>
        /// The TMP_InputField that the user will interact with.
        /// </summary>
        /// <remarks>
        /// This is the TMP_InputField whose text input will be used to set the value of the FloatVariable.
        /// It is also the TMP_InputField whose text will be updated to match the value of the FloatVariable when the TMP_InputField is not selected.
        /// </remarks>
        [FormerlySerializedAs("InputField")]
        [Tooltip("The TMP_InputField that the user will interact with.")]
        [SerializeField]
        private TMP_InputField inputField;

        /// <summary>
        /// The FloatVariable whose value will be used to set the InputField's text.
        /// </summary>
        /// <remarks>
        /// This is the FloatVariable whose value will be synchronized with the text input from the TMP_InputField.
        /// When the TMP_InputField is not selected, its text will be updated to match the value of this FloatVariable.
        /// When the text of the TMP_InputField is edited, this FloatVariable's value will be set to the parsed value of the new text.
        /// </remarks>
        [FormerlySerializedAs("Variable")]
        [Tooltip("The FloatVariable whose value will be used to set the InputField's text.")]
        [SerializeField]
        private FloatVariable variable;

        [SerializeField] private bool setOnAwake = true;

        /// <summary>
        /// A flag indicating whether the input field is currently selected.
        /// </summary>
        private bool isSelected = false;

        /// <summary>
        /// The last value of the FloatVariable. set to "0" by default.
        /// </summary>
        private string lastVariableValue = "0";

        /// <summary>
        /// Validates the InputField reference. Editor only.
        /// </summary>
        private void OnValidate()
        {
            if (inputField == null)
                inputField = GetComponent<TMP_InputField>();
        }

        /// <summary>
        /// Adds listeners for the onSelect, onDeselect, and onEndEdit events of the InputField.
        /// </summary>
        private void OnEnable()
        {
            inputField.onSelect.AddListener(OnSelect);
            inputField.onDeselect.AddListener(OnDeselect);
            inputField.onEndEdit.AddListener(OnDeselect);
            inputField.onEndEdit.AddListener(OnEndEdit);
        }

        /// <summary>
        /// Removes the listeners from the onSelect, onDeselect, and onEndEdit events of the InputField.
        /// </summary>
        private void OnDisable()
        {
            inputField.onSelect.RemoveListener(OnSelect);
            inputField.onDeselect.RemoveListener(OnDeselect);
            inputField.onDeselect.RemoveListener(OnEndEdit);
            inputField.onEndEdit.RemoveListener(OnDeselect);
            inputField.onEndEdit.RemoveListener(OnEndEdit);
        }

        /// <summary>
        /// Sets the text of the InputField to match the value of the FloatVariable when the script starts.
        /// </summary>
        private void Awake()
        {
            if (!setOnAwake) return;
            if (inputField == null || variable == null) return;
                
            inputField.text = variable.value.ToString("F2");
            lastVariableValue = variable.value.ToString();
        }

        /// <summary>
        /// Updates the text of the InputField to match the value of the FloatVariable, if the InputField is not currently selected.
        /// </summary>
        private void Update()
        {
            if (!isSelected && variable != null && !Mathf.Approximately(float.Parse(lastVariableValue), variable.value))
            {
                inputField.text = variable.value.ToString("F2");
                lastVariableValue = variable.value.ToString();
            }
        }

        /// <summary>
        /// Updates the value of the FloatVariable based on the parsed input text from the InputField,
        /// rounding to two decimal places, if the InputField is not currently selected.
        /// </summary>
        /// <param name="value">The new text of the InputField.</param>
        public void OnEndEdit(string value)
        {
            if (isSelected) return;
            
            if (float.TryParse(value, out var result))
            {
                // Round the number to 2 decimal places
                result = Mathf.Round(result * 100f) / 100f;
                variable.SetValue(result);
            }
            else
            {
                Debug.LogError("Invalid float value: " + value);
            }
        }

        /// <summary>
        /// Sets the isSelected flag to true when the InputField is selected.
        /// </summary>
        /// <param name="value">The current text of the InputField.</param>
        public void OnSelect(string value)
        {
            isSelected = true;
        }

        /// <summary>
        /// Sets the isSelected flag to false when the InputField is deselected.
        /// </summary>
        /// <param name="value">The current text of the InputField.</param>
        public void OnDeselect(string value)
        {
            isSelected = false;
        }
    }
}
