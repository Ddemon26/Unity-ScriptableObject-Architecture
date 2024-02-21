using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents an array of Material variables that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Material/MaterialArrayVariable")]
    public class MaterialArrayVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The array of Material variables.
        /// </summary>
        [Tooltip("The array of Material variables.")]
        public Material[] Value;

        /// <summary>
        /// Returns a Material from the array based on an index. 
        /// If the index is out of range, it returns the first Material in the array.
        /// </summary>
        /// <param name="index">The index of the Material to return.</param>
        /// <returns>The Material at the specified index, or the first Material if the index is out of range.</returns>
        public Material GetValue(int index)
        {
            if (index < 0 || index >= Value.Length)
            {
                Debug.LogWarning("Index out of range, returning first material in array.");
                return Value[0];
            }
            return Value[index];
        }

        /// <summary>
        /// Sets the array of Material variables to a new array.
        /// </summary>
        /// <param name="value">The new array of Material variables.</param>
        public void SetValue(Material[] value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the array of Material variables to the array from another MaterialArrayVariable.
        /// </summary>
        /// <param name="value">The MaterialArrayVariable to get the new array from.</param>
        public void SetValue(MaterialArrayVariable value)
        {
            Value = value.Value;
        }
    }
}