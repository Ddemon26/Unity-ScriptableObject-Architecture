using UnityEngine;
using TMPro;

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
        public TMP_Text TextComponent;

        /// <summary>
        /// The StringVariable whose value will be used to replace the text.
        /// </summary>
        [Tooltip("The StringVariable whose value will be used to replace the text.")]
        public StringVariable Variable;

        /// <summary>
        /// If set to true, the text will be updated every frame.
        /// </summary>
        [Tooltip("If set to true, the text will be updated every frame.")]
        public bool AlwaysUpdate;

        private string lastValue = "";

        /// <summary>
        /// Validates the TextMeshProUGUI component. Editor only.
        /// </summary>
        private void OnValidate()
        {
            if (TextComponent == null)
                TextComponent = GetComponent<TMP_Text>();
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
            UpdateText();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// If AlwaysUpdate is true, it updates the text of the TextMeshProUGUI component.
        /// </summary>
        private void Update()
        {
            if (AlwaysUpdate && Variable.Value != lastValue)
            {
                UpdateText();
            }
        }

        /// <summary>
        /// Updates the text of the TextMeshProUGUI component to the value of the StringVariable.
        /// </summary>
        private void UpdateText()
        {
            if (Variable != null && TextComponent != null)
            {
                TextComponent.text = Variable.Value;
                lastValue = Variable.Value;
            }
        }
    }
}