using UnityEngine;
using UnityEngine.Audio;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to set the volume of an AudioMixer based on the value of a FloatVariable.
    /// </summary>
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

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the volume of the AudioMixer to the value of the FloatVariable, converted to decibels.
        /// </summary>
        private void Update()
        {
            float dB = Variable.Value > 0.0f ?
                20.0f * Mathf.Log10(Variable.Value) :
                -80.0f;

            Mixer.SetFloat(ParameterName, dB);
        }
    }
}