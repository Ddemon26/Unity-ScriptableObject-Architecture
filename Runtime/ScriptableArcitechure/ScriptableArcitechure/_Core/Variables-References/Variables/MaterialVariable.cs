using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Material variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Material/MaterialVariable")]
    public class MaterialVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the Material variable.
        /// </summary>
        [Tooltip("The value of the Material variable.")]
        public Material Value;

        /// <summary>
        /// Sets the value of the Material variable from a Material.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Material value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Material variable from another MaterialVariable.
        /// </summary>
        /// <param name="value">The MaterialVariable to get the new value from.</param>
        public void SetValue(MaterialVariable value)
        {
            Value = value.Value;
        }
    }
}