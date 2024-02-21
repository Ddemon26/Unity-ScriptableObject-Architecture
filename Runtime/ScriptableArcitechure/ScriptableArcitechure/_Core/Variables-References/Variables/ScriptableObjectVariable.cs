using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a ScriptableObject variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Testing/ScriptableObjectVariable")]
    public class ScriptableObjectVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the ScriptableObject variable.
        /// </summary>
        [Tooltip("The value of the ScriptableObject variable.")]
        public ScriptableObject Value;

        /// <summary>
        /// Sets the value of the ScriptableObject variable from a ScriptableObject.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(ScriptableObject value)
        {
            if (value == null)
            {
                Debug.LogError("Cannot set null value to ScriptableObjectVariable.");
                return;
            }

            Value = value;
        }

        /// <summary>
        /// Sets the value of the ScriptableObject variable from another ScriptableObjectVariable.
        /// </summary>
        /// <param name="value">The ScriptableObjectVariable to get the new value from.</param>
        public void SetValue(ScriptableObjectVariable value)
        {
            if (value == null || value.Value == null)
            {
                Debug.LogError("Cannot set null value to ScriptableObjectVariable.");
                return;
            }

            Value = value.Value;
        }
    }
}