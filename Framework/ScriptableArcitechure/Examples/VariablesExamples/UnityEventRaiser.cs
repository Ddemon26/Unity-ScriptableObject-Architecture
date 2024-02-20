using UnityEngine;
using UnityEngine.Events;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to raise a UnityEvent when the game object is enabled.
    /// </summary>
    public class UnityEventRaiser : MonoBehaviour
    {
        /// <summary>
        /// The UnityEvent that will be raised when the game object is enabled.
        /// </summary>
        [Tooltip("The UnityEvent that will be raised when the game object is enabled.")]
        public UnityEvent OnEnableEvent;

        /// <summary>
        /// OnEnable is called when the object becomes enabled and active.
        /// It raises the OnEnableEvent.
        /// </summary>
        public void OnEnable()
        {
            OnEnableEvent.Invoke();
        }
    }
}