using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a boolean variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Variables/BoolVariable")]
    public class BoolVariable : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif
        [SerializeField, Tooltip("The value of the boolean variable.")]
        private bool value = false;

        /// <summary>
        /// The value of the boolean variable.
        /// </summary>
        public bool Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}