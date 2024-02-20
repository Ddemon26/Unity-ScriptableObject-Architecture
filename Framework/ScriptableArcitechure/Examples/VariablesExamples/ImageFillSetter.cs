﻿using UnityEngine;
using UnityEngine.UI;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Sets an Image component's fill amount to represent how far Variable is
    /// between Min and Max.
    /// </summary>
    public class ImageFillSetter : MonoBehaviour
    {
        /// <summary>
        /// The variable to use as the current value.
        /// </summary>
        [Tooltip("Value to use as the current ")]
        public FloatReference Variable;

        /// <summary>
        /// The minimum value that Variable can have for the Image to have no fill.
        /// </summary>
        [Tooltip("Min value that Variable to have no fill on Image.")]
        public FloatReference Min;

        /// <summary>
        /// The maximum value that Variable can be for the Image to be filled.
        /// </summary>
        [Tooltip("Max value that Variable can be to fill Image.")]
        public FloatReference Max;

        /// <summary>
        /// The Image to set the fill amount on.
        /// </summary>
        [Tooltip("Image to set the fill amount on.")]
        public Image Image;

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It sets the fill amount of the Image to represent how far Variable is between Min and Max.
        /// </summary>
        private void Update()
        {
            Image.fillAmount = Mathf.Clamp01(
                Mathf.InverseLerp(Min, Max, Variable));
        }
    }
}