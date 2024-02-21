using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [CreateAssetMenu(menuName = "ScriptableArchitect/Animation/AnimatorVariable")]
    public class AnimatorVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the Animator variable.
        /// </summary>
        [Tooltip("The value of the Animator variable.")]
        public Animator Value;

        /// <summary>
        /// Sets the value of the Animator variable from an Animator.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(Animator value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the Animator variable from another AnimatorVariable.
        /// </summary>
        /// <param name="value">The AnimatorVariable to get the new value from.</param>
        public void SetValue(AnimatorVariable value)
        {
            Value = value.Value;
        }
    }
}