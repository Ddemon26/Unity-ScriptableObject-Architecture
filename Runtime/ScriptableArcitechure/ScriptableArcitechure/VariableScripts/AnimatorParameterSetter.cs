using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Takes a FloatVariable and sends its value to an Animator parameter 
    /// every frame on Update.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AnimatorSetters/Animator Parameter Setter")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(Animator))]
    public class AnimatorParameterSetter : MonoBehaviour
    {
        /// <summary>
        /// Variable to read from and send to the Animator as the specified parameter.
        /// </summary>
        [Tooltip("Variable to read from and send to the Animator as the specified parameter.")]
        public FloatVariable Variable;

        /// <summary>
        /// Animator to set parameters on.
        /// </summary>
        [Tooltip("Animator to set parameters on.")]
        public Animator Animator;

        /// <summary>
        /// Name of the parameter to set with the value of Variable.
        /// </summary>
        [Tooltip("Name of the parameter to set with the value of Variable.")]
        public string ParameterName;

        /// <summary>
        /// Animator Hash of ParameterName, automatically generated.
        /// </summary>
        [Tooltip("Animator Hash of ParameterName, automatically generated.")]
        [SerializeField] private int parameterHash;

        private float lastValue = 0;

        /// <summary>
        /// OnValidate is called when the script is loaded or a value is changed in the Inspector.
        /// It sets the parameterHash to the hash of the ParameterName.
        /// </summary>
        private void OnValidate()
        {
            if (Animator == null)
                Animator = GetComponent<Animator>();
            parameterHash = Animator.StringToHash(ParameterName);
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the value of the Animator parameter with the hash of parameterHash to the value of the Variable.
        /// </summary>
        private void Update()
        {
            if (Variable.value != lastValue)
            {
                Animator.SetFloat(parameterHash, Variable.value);
                lastValue = Variable.value;
            }
        }
    }
}