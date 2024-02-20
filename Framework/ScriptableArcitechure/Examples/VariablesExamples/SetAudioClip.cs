using ScriptableArchitect.Variables;
using UnityEngine;

namespace ScriptableArchitect.Sets
{
    [AddComponentMenu("Scriptable Architecture/SetVariables/SetAudioClip")]
    [RequireComponent(typeof(AudioSource))]
    public class SetAudioClip : MonoBehaviour
    {
        [SerializeField] AudioClipReference audioClipRef;
        [SerializeField] AudioSource audioSource;
        [SerializeField] bool playOnAwake;
        [SerializeField] bool alwaysUpdate;


        private void Awake()
        {
            if (playOnAwake)
            {
                audioSource.clip = audioClipRef.Value;
                audioSource.Play();
            }
        }
        private void Update()
        {
            if (alwaysUpdate)
            {
                audioSource.clip = audioClipRef.Value;
            }
        }
    }
}