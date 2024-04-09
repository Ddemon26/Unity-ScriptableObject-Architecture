using TMPro;
using UnityEngine;

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
        [Tooltip("The TMP_InputField that the user will interact with.")]
        [SerializeField] TMP_InputField InputField;

        /// <summary>
        /// The FloatVariable whose value will be used to set the InputField's text.
        /// </summary>
        /// <remarks>
        /// This is the FloatVariable whose value will be synchronized with the text input from the TMP_InputField.
        /// When the TMP_InputField is not selected, its text will be updated to match the value of this FloatVariable.
        /// When the text of the TMP_InputField is edited, this FloatVariable's value will be set to the parsed value of the new text.
        /// </remarks>
        [Tooltip("The FloatVariable whose value will be used to set the InputField's text.")]
        [SerializeField] FloatVariable Variable;

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
            if (InputField == null)
                InputField = GetComponent<TMP_InputField>();
        }

        /// <summary>
        /// Adds listeners for the onSelect, onDeselect, and onEndEdit events of the InputField.
        /// </summary>
        private void OnEnable()
        {
            InputField.onSelect.AddListener(OnSelect);
            InputField.onDeselect.AddListener(OnDeselect);
            InputField.onEndEdit.AddListener(OnDeselect);
            InputField.onEndEdit.AddListener(OnEndEdit);
        }

        /// <summary>
        /// Removes the listeners from the onSelect, onDeselect, and onEndEdit events of the InputField.
        /// </summary>
        private void OnDisable()
        {
            InputField.onSelect.RemoveListener(OnSelect);
            InputField.onDeselect.RemoveListener(OnDeselect);
            InputField.onDeselect.RemoveListener(OnEndEdit);
            InputField.onEndEdit.RemoveListener(OnDeselect);
            InputField.onEndEdit.RemoveListener(OnEndEdit);
        }

        /// <summary>
        /// Sets the text of the InputField to match the value of the FloatVariable when the script starts.
        /// </summary>
        private void Awake()
        {
            if (setOnAwake)
            {
                if (InputField != null && Variable != null)
                {
                    InputField.text = Variable.value.ToString("F2");
                    lastVariableValue = Variable.value.ToString();
                }
            }
        }

        /// <summary>
        /// Updates the text of the InputField to match the value of the FloatVariable, if the InputField is not currently selected.
        /// </summary>
        private void Update()
        {
            if (!isSelected && Variable != null && !Mathf.Approximately(float.Parse(lastVariableValue), Variable.value))
            {
                InputField.text = Variable.value.ToString("F2");
                lastVariableValue = Variable.value.ToString();
            }
        }

        /// <summary>
        /// Updates the value of the FloatVariable based on the parsed input text from the InputField,
        /// rounding to two decimal places, if the InputField is not currently selected.
        /// </summary>
        /// <param name="value">The new text of the InputField.</param>
        public void OnEndEdit(string value)
        {
            if (!isSelected)
            {
                if (float.TryParse(value, out float result))
                {
                    // Round the number to 2 decimal places
                    result = Mathf.Round(result * 100f) / 100f;
                    Variable.SetValue(result);
                }
                else
                {
                    Debug.LogError("Invalid float value: " + value);
                }
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
