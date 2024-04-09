using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/Variable Audio Trigger")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class VariableAudioTrigger : MonoBehaviour
    {
        [Tooltip("The AudioSource that will be triggered.")]
        public AudioSource audioSource;
        [Tooltip("The FloatVariable that will be monitored.")]
        public FloatVariable variable;
        [Tooltip("The threshold below which the AudioSource will be triggered.")]
        public FloatReference lowThreshold;

        private bool isPlaying;
        private void Update()
        {
            if (variable < lowThreshold)
            {
                if (isPlaying) return;
                audioSource.Play();
                isPlaying = true;
            }
            else
            {
                if (!isPlaying) return;
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}