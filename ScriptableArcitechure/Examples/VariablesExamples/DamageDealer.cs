using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a damage dealer in the game.
    /// It contains a damage amount that can be applied to other game objects.
    /// </summary>
    public class DamageDealer : MonoBehaviour
    {
        /// <summary>
        /// The amount of damage that this damage dealer can deal.
        /// </summary>
        [Tooltip("The amount of damage that this damage dealer can deal.")]
        public FloatReference DamageAmount;
    }
}