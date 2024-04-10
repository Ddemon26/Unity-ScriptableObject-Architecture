// ----------------------------------------------------------------------------
// Created by: TentCity Software
// Author: Damon Fedorick
// Date: 01/01/2024
// Version: 1.0.1
// 
// Copyright (c) 2023 TentCity Software. All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// ----------------------------------------------------------------------------

using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a simple unit with health points in the game.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/Examples/Simple Unit Health")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class SimpleUnitHealth : MonoBehaviour
    {
        /// <summary>
        /// The health points of the unit.
        /// </summary>
        [Tooltip("The health points of the unit.")]
        public FloatVariable hp;

        /// <summary>
        /// If set to true, the health points will be reset to the starting health points when the game starts.
        /// </summary>
        [Tooltip("If set to true, the health points will be reset to the starting health points when the game starts.")]
        public bool resetHp;

        /// <summary>
        /// The starting health points of the unit.
        /// </summary>
        [Tooltip("The starting health points of the unit.")]
        public FloatReference startingHp;

        /// <summary>
        /// Start is called before the first frame update.
        /// If ResetHP is true, it sets the health points to the starting health points.
        /// </summary>
        private void Start()
        {
            if (resetHp)
                hp.SetValue(startingHp);
        }

        /// <summary>
        /// This method is called when the Collider other enters the trigger.
        /// If the other collider has a DamageDealer component, it applies the damage to the health points.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            var damage = other.gameObject.GetComponent<DamageDealer>();
            if (damage != null)
                hp.ApplyChange(-damage.damageAmount);
        }
    }
}