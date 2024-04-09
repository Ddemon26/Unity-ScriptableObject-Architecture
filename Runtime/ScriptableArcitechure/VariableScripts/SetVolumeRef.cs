using ScriptableArchitect.Variables;
using UnityEngine;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Sets the volume of an AudioSource based on a FloatReference.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/SetVolumeRef")]
    [RequireComponent(typeof(AudioSource))]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class SetVolumeRef : MonoBehaviour
    {
        /// <summary>
        /// The AudioSource whose volume will be set.
        /// </summary>
        [Tooltip("The AudioSource whose volume will be set.")]
        [SerializeField]
        private AudioSource audioSource;

        /// <summary>
        /// Reference to the FloatReference that controls the volume.
        /// </summary>
        [Tooltip("Reference to the FloatReference that controls the volume.")]
        [SerializeField]
        private FloatReference volumeRef;

        /// <summary>
        /// Multiplier for the volume value.
        /// </summary>
        [Tooltip("Multiplier for the volume value.")]
        [SerializeField]
        private float volumeMultiplier = 1;

        /// <summary>
        /// The last volume value, used to check if the volume has changed.
        /// </summary>
        private float lastVolume = 1;

        /// <summary>
        /// Validates the AudioSource component.
        /// </summary>
        private void OnValidate()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// when the script calls start, it sets the volume of the AudioSource to the value of the FloatReference.
        /// </summary>
        private void Start()
        {
            audioSource.volume = volumeRef.Value * volumeMultiplier;
            lastVolume = volumeRef.Value;
        }
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the volume of the AudioSource to the value of the FloatReference.
        /// </summary>
        private void Update()
        {
            if (volumeRef.Value != lastVolume)
            {
                audioSource.volume = volumeRef.Value * volumeMultiplier;
                lastVolume = volumeRef.Value;
            }
        }
    }
}