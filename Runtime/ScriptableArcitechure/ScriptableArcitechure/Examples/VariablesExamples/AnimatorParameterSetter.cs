using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Takes a FloatVariable and sends its value to an Animator parameter 
    /// every frame on Update.
    /// </summary>
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

        /// <summary>
        /// OnValidate is called when the script is loaded or a value is changed in the Inspector.
        /// It sets the parameterHash to the hash of the ParameterName.
        /// </summary>
        private void OnValidate()
        {
            parameterHash = Animator.StringToHash(ParameterName);
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the value of the Animator parameter with the hash of parameterHash to the value of the Variable.
        /// </summary>
        private void Update()
        {
            Animator.SetFloat(parameterHash, Variable.Value);
        }
    }
}