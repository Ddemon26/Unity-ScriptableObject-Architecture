using UnityEngine;

namespace ScriptableArchitect.Variables
{
    public class ScaleTimeAnimator : MonoBehaviour
    {
        public Animator Animator;
        public BoolVariable stopAnimator;
        public bool invertSetting;

        private void Update()
        {
            if (invertSetting)
            {
                if (stopAnimator.Value)
                {
                    Animator.speed = 0;
                }
                else
                {
                    Animator.speed = 1;
                }
            }
            else
            {
                if (!stopAnimator.Value)
                {
                    Animator.speed = 0;
                }
                else
                {
                    Animator.speed = 1;
                }
            }
        }
    }
}