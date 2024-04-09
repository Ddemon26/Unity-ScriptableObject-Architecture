using UnityEngine;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Represents a 'Thing' object that can be added to or removed from a 'ThingRuntimeSet'.
    /// This class is a MonoBehaviour and should be attached to a GameObject.
    /// </summary>
    public class Thing : MonoBehaviour
    {
        [Tooltip("The runtime set this 'Thing' belongs to.")]
        public ThingRuntimeSet RuntimeSet;

        /// <summary>
        /// Adds this 'Thing' to its 'ThingRuntimeSet' when enabled.
        /// </summary>
        private void OnEnable()
        {
            RuntimeSet.Add(this);
        }

        /// <summary>
        /// Removes this 'Thing' from its 'ThingRuntimeSet' when disabled.
        /// </summary>
        private void OnDisable()
        {
            RuntimeSet.Remove(this);
        }
    }
}