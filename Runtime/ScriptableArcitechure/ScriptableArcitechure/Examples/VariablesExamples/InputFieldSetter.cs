using TMPro;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to set the value of a FloatVariable based on the input from a TMP_InputField.
    /// It executes in both edit and play modes.
    /// </summary>
    [ExecuteInEditMode]
    public class InputFieldSetter : MonoBehaviour
    {
        /// <summary>
        /// The TMP_InputField that the user will interact with.
        /// </summary>
        [Tooltip("The TMP_InputField that the user will interact with.")]
        [SerializeField] TMP_InputField InputField;

        /// <summary>
        /// The FloatVariable whose value will be used to set the InputField's text.
        /// </summary>
        [Tooltip("The FloatVariable whose value will be used to set the InputField's text.")]
        [SerializeField] FloatVariable Variable;

        /// <summary>
        /// A flag indicating whether the input field is currently selected.
        /// </summary>
        public bool isSelected = false;

        /// <summary>
        /// Validates the InputField reference.
        /// </summary>
        private void OnValidate()
        {
            if (InputField == null)
                InputField = GetComponent<TMP_InputField>();
        }

        /// <summary>
        /// Adds listeners for the onSelect, onDeselect, and onEndEdit events of the InputField.
        /// </summary>
        private void Awake()
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
        /// Updates the text of the InputField to match the value of the FloatVariable, if the InputField is not currently selected.
        /// </summary>
        private void Update()
        {
            if (!isSelected)
            {
                InputField.text = Variable.Value.ToString();
            }
        }

        /// <summary>
        /// Sets the value of the FloatVariable to the parsed value of the InputField's text, if the InputField is not currently selected.
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
                    Variable.SetValueWithClamp(result);
                    //InputField.text = Variable.Value.ToString();
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
