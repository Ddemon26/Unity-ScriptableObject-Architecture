using System;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class is used to move a game object using keyboard input.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Legacy/Input/Keyboard Mover")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class KeyboardMover : MonoBehaviour
    {
        /// <summary>
        /// This class represents an axis of movement, with positive and negative directions corresponding to different keys.
        /// </summary>
        [Serializable]
        public class MoveAxis
        {
            /// <summary>
            /// The key that corresponds to positive movement along the axis.
            /// </summary>
            [Tooltip("The key that corresponds to positive movement along the axis.")]
            public KeyCode Positive;
            /// <summary>
            /// The key that corresponds to negative movement along the axis.
            /// </summary>
            [Tooltip("The key that corresponds to negative movement along the axis.")]
            public KeyCode Negative;

            public MoveAxis(KeyCode positive, KeyCode negative)
            {
                Positive = positive;
                Negative = negative;
            }
            /// <summary>
            /// Converts the MoveAxis to a float representing the current movement along the axis.
            /// Positive if the Positive key is pressed, negative if the Negative key is pressed, and zero otherwise.
            /// </summary>
            public static implicit operator float(MoveAxis axis)
            {
                return (Input.GetKey(axis.Positive)
                    ? 1.0f : 0.0f) -
                    (Input.GetKey(axis.Negative)
                    ? 1.0f : 0.0f);
            }
        }
        /// <summary>
        /// The rate of movement.
        /// </summary>
        [Tooltip("The rate of movement.")]
        public FloatVariable MoveRate;

        /// <summary>
        /// The horizontal axis of movement.
        /// </summary>
        [Tooltip("The horizontal axis of movement.")]
        public MoveAxis Horizontal = new MoveAxis(KeyCode.D, KeyCode.A);

        /// <summary>
        /// The vertical axis of movement.
        /// </summary>
        [Tooltip("The vertical axis of movement.")]
        public MoveAxis Vertical = new MoveAxis(KeyCode.W, KeyCode.S);

        /// <summary>
        /// Update is called once per frame.
        /// It moves the game object according to the input from the horizontal and vertical axes.
        /// </summary>
        private void Update()
        {
            Vector3 moveNormal = new Vector3(Horizontal, Vertical, 0.0f).normalized;

            transform.position += moveNormal * Time.deltaTime * MoveRate.Value;
        }
    }
}