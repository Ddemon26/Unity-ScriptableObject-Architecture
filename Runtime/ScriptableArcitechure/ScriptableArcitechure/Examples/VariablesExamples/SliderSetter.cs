using UnityEngine;
using UnityEngine.UI;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to set the value of a Slider component with the value of a FloatVariable.
    /// It executes in both edit and play modes.
    /// </summary>
    [ExecuteInEditMode]
    public class SliderSetter : MonoBehaviour
    {
        /// <summary>
        /// The Slider component whose value will be set.
        /// </summary>
        [SerializeField] Slider Slider;

        /// <summary>
        /// The FloatVariable whose value will be used to set the Slider's value.
        /// </summary>
        [SerializeField] FloatVariable Variable;

        /// <summary>
        /// Validates the Slider component.
        /// </summary>
        private void OnValidate()
        {
            if (Slider == null)
                Slider = GetComponent<Slider>();
        }

        /// <summary>
        /// Adds a listener to the Slider's onValueChanged event.
        /// </summary>
        private void Awake()
        {
            Slider.onValueChanged.AddListener(OnValueChange);
        }

        /// <summary>
        /// Removes the listener from the Slider's onValueChanged event.
        /// </summary>
        private void OnDisable()
        {
            Slider.onValueChanged.RemoveListener(OnValueChange);
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the value of the Slider to the value of the FloatVariable.
        /// </summary>
        private void Update()
        {
            if (Slider != null && Variable != null)
                Slider.value = Variable.Value;
        }

        /// <summary>
        /// Sets the value of the FloatVariable to the value of the Slider.
        /// </summary>
        /// <param name="value">The new value of the Slider.</param>
        public void OnValueChange(float value)
        {
            Variable.SetValueWithClamp(value);
        }
    }
}
