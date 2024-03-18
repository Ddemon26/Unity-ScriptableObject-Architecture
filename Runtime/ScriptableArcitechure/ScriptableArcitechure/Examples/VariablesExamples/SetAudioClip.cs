using ScriptableArchitect.Variables;
using UnityEngine;

namespace ScriptableArchitect.Sets
{
    /// <summary>
    /// Sets an AudioClip to an AudioSource and controls its playback.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/AudioSetters/SetAudioClip")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [RequireComponent(typeof(AudioSource))]
    public class SetAudioClip : MonoBehaviour
    {
        /// <summary>
        /// The AudioSource to which the AudioClip will be set.
        /// </summary>
        [Tooltip("The AudioSource to which the AudioClip will be set.")]
        [SerializeField] AudioSource audioSource;

        /// <summary>
        /// Reference to the AudioClip to be set.
        /// </summary>
        [Tooltip("Reference to the AudioClip to be set.")]
        [SerializeField] AudioClipReference audioClipRef;

        /// <summary>
        /// If true, the AudioClip will be set and played on Awake.
        /// </summary>
        [Tooltip("If true, the AudioClip will be set and played on Awake.")]
        [SerializeField] bool playOnAwake;

        /// <summary>
        /// If true, the AudioClip will be updated every frame.
        /// </summary>
        [Tooltip("If true, the AudioClip will be updated every frame.")]
        [SerializeField] bool alwaysUpdate;

        private void OnValidate()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }
        private void Awake()
        {
            if (playOnAwake)
            {
                SetClipAndPlay();
            }
        }

        private void Update()
        {
            if (alwaysUpdate && audioSource.clip != audioClipRef.Value)
            {
                SetClipAndPlay();
            }
        }

        /// <summary>
        /// Sets the AudioClip to the AudioSource and plays it if it's not already playing.
        /// </summary>
        private void SetClipAndPlay()
        {
            audioSource.clip = audioClipRef.Value;
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
    }
}