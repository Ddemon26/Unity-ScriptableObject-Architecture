using System.Collections.Generic;
using UnityEngine;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Represents a runtime set of generic type T.
    /// This class is a ScriptableObject and can be created via the Unity editor.
    /// </summary>
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        /// <summary>
        /// List of items of type T.
        /// </summary>
        public List<T> Items = new List<T>();

        /// <summary>
        /// Adds an item to the set.
        /// </summary>
        /// <param name="thing">The item to add.</param>
        public void Add(T thing)
        {
            if (!Items.Contains(thing))
                Items.Add(thing);
        }

        /// <summary>
        /// Removes an item from the set.
        /// </summary>
        /// <param name="thing">The item to remove.</param>
        public void Remove(T thing)
        {
            if (Items.Contains(thing))
                Items.Remove(thing);
        }
    }
}