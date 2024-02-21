using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Prefab array variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/GameObject/PrefabArrayVariable")]
    public class PrefabArrayVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the Prefab array variable.
        /// </summary>
        [Tooltip("The value of the Prefab array variable. Note: These should be prefabs, not live game objects.")]
        public GameObject[] Value;

        /// <summary>
        /// Sets the value of the Prefab array variable from a GameObject array.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(GameObject[] value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Prefab array variable from another PrefabArrayVariable.
        /// </summary>
        /// <param name="value">The PrefabArrayVariable to get the new value from.</param>
        public void SetValue(PrefabArrayVariable value)
        {
            Value = value.Value;
        }
    }
}