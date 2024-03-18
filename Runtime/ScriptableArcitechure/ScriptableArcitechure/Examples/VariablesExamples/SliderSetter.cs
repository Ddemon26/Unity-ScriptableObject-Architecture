using UnityEngine;
using UnityEngine.UI;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to set the value of a Slider component with the value of a FloatVariable.
    /// It executes in both edit and play modes.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/UISetters/SliderSetter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(Slider))]
    [ExecuteInEditMode]
    public class SliderSetter : MonoBehaviour
    {
        /// <summary>
        /// The Slider component whose value will be set.
        /// </summary>
        [Tooltip("The Slider component whose value will be set.")]
        [SerializeField] Slider Slider;

        /// <summary>
        /// The FloatVariable whose value will be used to set the Slider's value.
        /// </summary>
        [Tooltip("The FloatVariable whose value will be used to set the Slider's value.")]
        [SerializeField] FloatVariable Variable;

        private float lastVariableValue = 0;

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
        private void OnEnable()
        {
            if (Slider != null)
            {
                Slider.onValueChanged.AddListener(OnValueChange);
            }
        }

        /// <summary>
        /// Removes the listener from the Slider's onValueChanged event.
        /// </summary>
        private void OnDisable()
        {
            if (Slider != null)
            {
                Slider.onValueChanged.RemoveListener(OnValueChange);
            }
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the value of the Slider to the value of the FloatVariable.
        /// </summary>
        private void Update()
        {
            if (Slider != null && Variable != null && !Mathf.Approximately(lastVariableValue, Variable.Value))
            {
                Slider.value = Variable.Value;
                lastVariableValue = Variable.Value;
            }
        }

        /// <summary>
        /// Sets the value of the FloatVariable to the value of the Slider.
        /// </summary>
        /// <param name="value">The new value of the Slider.</param>
        public void OnValueChange(float value)
        {
            if (Variable != null)
            {
                Variable.SetValueWithClamp(value);
            }
        }
    }
}