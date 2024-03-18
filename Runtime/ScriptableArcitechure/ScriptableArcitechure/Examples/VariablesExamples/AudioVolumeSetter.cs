using UnityEngine;
using UnityEngine.Audio;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to set the volume of an AudioMixer based on the value of a FloatVariable.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/AudioVolumeSetter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class AudioVolumeSetter : MonoBehaviour
    {
        /// <summary>
        /// The AudioMixer whose volume will be set.
        /// </summary>
        [Tooltip("The AudioMixer whose volume will be set.")]
        public AudioMixer Mixer;

        /// <summary>
        /// The name of the volume parameter in the AudioMixer.
        /// </summary>
        [Tooltip("The name of the volume parameter in the AudioMixer.")]
        public string ParameterName = "";

        /// <summary>
        /// The FloatVariable that represents the volume. Its value should be between 0.0 (silent) and 1.0 (full volume).
        /// </summary>
        [Tooltip("The FloatVariable that represents the volume. Its value should be between 0.0 (silent) and 1.0 (full volume).")]
        public FloatVariable Variable;

        private float lastValue = 0;

        private void Awake()
        {
            if (Mixer == null)
            {
                Debug.LogError("AudioMixer is not set in the AudioVolumeSetter component.");
                return;
            }

            if (string.IsNullOrEmpty(ParameterName))
            {
                Debug.LogError("ParameterName is not set in the AudioVolumeSetter component.");
                return;
            }

            if (Variable == null)
            {
                Debug.LogError("FloatVariable is not set in the AudioVolumeSetter component.");
                return;
            }

            SetVolume(Variable.Value);
        }

        private void SetVolume(float volume)
        {
            Mixer.SetFloat(ParameterName, volume);
            lastValue = volume;
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the volume of the AudioMixer to the value of the FloatVariable, converted to decibels.
        /// </summary>
        private void Update()
        {
            if (Variable.Value != lastValue)
            {
                float dB = Variable.Value > 0.0f ?
                    20.0f * Mathf.Log10(Variable.Value) :
                    -80.0f;

                Mixer.SetFloat(ParameterName, dB);
                lastValue = Variable.Value;
            }
        }
    }
}