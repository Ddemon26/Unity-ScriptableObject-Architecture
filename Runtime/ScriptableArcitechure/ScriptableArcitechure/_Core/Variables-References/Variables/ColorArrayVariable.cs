using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents an array of Color variables that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Material/ColorArrayVariable")]
    public class ColorArrayVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The array of Color variables.
        /// </summary>
        [Tooltip("The array of Color variables.")]
        public Color[] Value;

        /// <summary>
        /// Returns a Color from the array based on an index. 
        /// If the index is out of range, it returns the first Color in the array.
        /// </summary>
        /// <param name="index">The index of the Color to return.</param>
        /// <returns>The Color at the specified index, or the first Color if the index is out of range.</returns>
        public Color GetValue(int index)
        {
            if (index < 0 || index >= Value.Length)
            {
                Debug.LogWarning("Index out of range, returning first color in array.");
                return Value[0];
            }
            return Value[index];
        }

        /// <summary>
        /// Sets the array of Color variables to a new array.
        /// </summary>
        /// <param name="value">The new array of Color variables.</param>
        public void SetValue(Color[] value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the array of Color variables to the array from another ColorArrayVariable.
        /// </summary>
        /// <param name="value">The ColorArrayVariable to get the new array from.</param>
        public void SetValue(ColorArrayVariable value)
        {
            Value = value.Value;
        }
    }
}