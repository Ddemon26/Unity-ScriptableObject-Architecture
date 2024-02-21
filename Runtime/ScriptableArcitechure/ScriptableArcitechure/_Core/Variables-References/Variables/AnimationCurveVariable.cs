using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents an AnimationCurve variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Animation/AnimationCurveVariable")]
    public class AnimationCurveVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string DeveloperDescription = "";
#endif

        /// <summary>
        /// The current value of the AnimationCurve variable.
        /// </summary>
        [Tooltip("The value of the AnimationCurve variable.")]
        public AnimationCurve Value;

        /// <summary>
        /// Sets the value of the AnimationCurve variable from an AnimationCurve.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void SetValue(AnimationCurve value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of the AnimationCurve variable from another AnimationCurveVariable.
        /// </summary>
        /// <param name="value">The AnimationCurveVariable to get the new value from.</param>
        public void SetValue(AnimationCurveVariable value)
        {
            Value = value.Value;
        }
    }
}