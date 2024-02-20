using UnityEngine;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// This class is responsible for disabling 'Thing' objects in a 'ThingRuntimeSet'.
    /// It provides methods to disable all 'Thing' objects or disable a random 'Thing' object.
    /// </summary>
    public class ThingDisabler : MonoBehaviour
    {
        [Tooltip("The runtime set of 'Thing' objects to be disabled.")]
        public ThingRuntimeSet Set;

        /// <summary>
        /// Disables all 'Thing' objects in the 'ThingRuntimeSet'.
        /// </summary>
        public void DisableAll()
        {
            // Loop backwards since the list may change when disabling
            for (int i = Set.Items.Count - 1; i >= 0; i--)
            {
                Set.Items[i].gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Disables a random 'Thing' object in the 'ThingRuntimeSet'.
        /// </summary>
        public void DisableRandom()
        {
            int index = Random.Range(0, Set.Items.Count);
            Set.Items[index].gameObject.SetActive(false);
        }
    }
}