using UnityEngine;
using UnityEngine.Audio;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Takes a FloatVariable and sends a curve filtered version of its value 
    /// to an exposed audio mixer parameter every frame on Update.
    /// </summary>
    public class AudioParameterSetter : MonoBehaviour
    {
        /// <summary>
        /// Mixer to set the parameter in.
        /// </summary>
        [Tooltip("Mixer to set the parameter in.")]
        public AudioMixer Mixer;

        /// <summary>
        /// Name of the parameter to set in the mixer.
        /// </summary>
        [Tooltip("Name of the parameter to set in the mixer.")]
        public string ParameterName = "";

        /// <summary>
        /// Variable to send to the mixer parameter.
        /// </summary>
        [Tooltip("Variable to send to the mixer parameter.")]
        public FloatVariable Variable;

        /// <summary>
        /// Minimum value of the Variable that is mapped to the curve.
        /// </summary>
        [Tooltip("Minimum value of the Variable that is mapped to the curve.")]
        public FloatReference Min;

        /// <summary>
        /// Maximum value of the Variable that is mapped to the curve.
        /// </summary>
        [Tooltip("Maximum value of the Variable that is mapped to the curve.")]
        public FloatReference Max;

        /// <summary>
        /// Curve to evaluate in order to look up a final value to send as the parameter.
        /// T=0 is when Variable == Min
        /// T=1 is when Variable == Max
        /// </summary>
        [Tooltip("Curve to evaluate in order to look up a final value to send as the parameter.\n" +
                 "T=0 is when Variable == Min\n" +
                 "T=1 is when Variable == Max")]
        public AnimationCurve Curve;

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It calculates a value based on the Variable, Min, Max, and Curve, and sets the ParameterName parameter of the Mixer to this value.
        /// </summary>
        private void Update()
        {
            float t = Mathf.InverseLerp(Min.Value, Max.Value, Variable.Value);
            float value = Curve.Evaluate(Mathf.Clamp01(t));
            Mixer.SetFloat(ParameterName, value);
        }
    }
}