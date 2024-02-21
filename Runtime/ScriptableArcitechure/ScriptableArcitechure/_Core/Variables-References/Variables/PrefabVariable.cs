using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a prefab variable that can be created as a ScriptableObject.
    /// Note: This can only deal with prefabs and not live GameObjects.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/GameObject/PrefabVariable")]
    public class PrefabVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the prefab variable.
        /// </summary>
        [Tooltip("The value of the prefab variable.")]
        public GameObject Value;

        /// <summary>
        /// Sets the value of the prefab variable from a GameObject.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(GameObject value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the prefab variable from another PrefabVariable.
        /// </summary>
        /// <param name="value">The PrefabVariable to get the new value from.</param>
        public void SetValue(PrefabVariable value)
        {
            Value = value.Value;
        }
    }
}