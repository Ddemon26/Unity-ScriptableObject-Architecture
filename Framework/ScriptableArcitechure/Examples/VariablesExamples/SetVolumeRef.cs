using ScriptableArchitect.Variables;
using UnityEngine;

namespace ScriptableArchitect.Sets
{
    [AddComponentMenu("Scriptable Architecture/SetVariables/SetVolumeRef")]
    [RequireComponent(typeof(AudioSource))]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    [ExecuteInEditMode]
    public class SetVolumeRef : MonoBehaviour
    {
        [SerializeField] FloatReference volumeRef;
        [SerializeField] AudioSource audioSource;

        private void Update()
        {
            audioSource.volume = volumeRef.Value;
        }
    }
}