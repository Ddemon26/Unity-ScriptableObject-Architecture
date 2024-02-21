using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [CreateAssetMenu(menuName = "ScriptableArchitect/Animation/AnimationVariable")]
    public class AnimationVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the Animation variable.
        /// </summary>
        [Tooltip("The value of the Animation variable.")]
        public AnimationClip Value;

        /// <summary>
        /// Sets the value of the Animation variable from an AnimationClip.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(AnimationClip value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Animation variable from another AnimationVariable.
        /// </summary>
        /// <param name="value">The AnimationVariable to get the new value from.</param>
        public void SetValue(AnimationVariable value)
        {
            Value = value.Value;
        }
    }
}