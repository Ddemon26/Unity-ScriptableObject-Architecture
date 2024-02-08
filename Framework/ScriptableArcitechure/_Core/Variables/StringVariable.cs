using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [CreateAssetMenu(menuName = "Variables/StringVariable")]
    public class StringVariable : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Description of the variable, only visible in the Unity editor.
        /// </summary>
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        [SerializeField]
        private string value = "";

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}