using UnityEngine;
using TMPro;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// This class is used to monitor the count of items in a ThingRuntimeSet and display it in a TextMeshProUGUI component.
    /// </summary>
    public class ThingMonitor : MonoBehaviour
    {
        /// <summary>
        /// The ThingRuntimeSet whose items count will be monitored.
        /// </summary>
        [Tooltip("The runtime set of 'Thing' objects to monitor.")]
        public ThingRuntimeSet Set;

        /// <summary>
        /// The TextMeshProUGUI component where the items count will be displayed.
        /// </summary>
        [Tooltip("The TextMeshProUGUI component to display the items count.")]
        public TMP_Text TextComponent;

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
            if (previousCount != Set.Items.Count)
            {
                UpdateText();
                previousCount = Set.Items.Count;
            }
        }
        /// <summary>
        /// Updates the text of the TextMeshProUGUI component to display the current count of items.
        /// </summary>
        public void UpdateText()
        {
            TextComponent.text = "There are " + Set.Items.Count + " things.";
        }
    }
}