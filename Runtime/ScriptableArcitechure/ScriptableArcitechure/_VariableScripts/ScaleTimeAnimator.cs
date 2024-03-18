using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Controls the speed of an Animator based on a Boolean variable.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AnimatorSetters/ScaleTimeAnimator", 1)]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(Animator))]
    public class ScaleTimeAnimator : MonoBehaviour
    {
        /// <summary>
        /// The Animator whose speed is to be controlled.
        /// </summary>
        [Tooltip("The Animator whose speed is to be controlled.")]
        [SerializeField] Animator Animator;

        /// <summary>
        /// The Boolean variable that determines whether the Animator should be stopped or not.
        /// </summary>
        [Tooltip("The Boolean variable that determines whether the Animator should be stopped or not.")]
        [SerializeField] BoolVariable stopAnimator;

        /// <summary>
        /// If set to true, the Animator will be stopped when stopAnimator is false and vice versa.
        /// </summary>
        [Tooltip("If set to true, the Animator will be stopped when stopAnimator is false and vice versa.")]
        [SerializeField] bool invertSetting;

        /// <summary>
        /// Validates the Animator component.
        /// </summary>
        void OnValidate()
        {
            if (Animator == null)
                Animator = GetComponent<Animator>();
        }
        /// <summary>
        /// Updates the Animator speed based on the stopAnimator value and invertSetting.
        /// </summary>
        private void Update()
        {
            Animator.speed = (stopAnimator.Value ^ invertSetting) ? 1 : 0;
        }
    }
}