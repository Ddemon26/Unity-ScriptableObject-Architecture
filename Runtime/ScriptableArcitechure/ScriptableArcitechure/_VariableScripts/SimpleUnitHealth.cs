using UnityEngine;

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
        public FloatVariable HP;

        /// <summary>
        /// If set to true, the health points will be reset to the starting health points when the game starts.
        /// </summary>
        [Tooltip("If set to true, the health points will be reset to the starting health points when the game starts.")]
        public bool ResetHP;

        /// <summary>
        /// The starting health points of the unit.
        /// </summary>
        [Tooltip("The starting health points of the unit.")]
        public FloatReference StartingHP;

        /// <summary>
        /// Start is called before the first frame update.
        /// If ResetHP is true, it sets the health points to the starting health points.
        /// </summary>
        private void Start()
        {
            if (ResetHP)
                HP.SetValue(StartingHP);
        }

        /// <summary>
        /// This method is called when the Collider other enters the trigger.
        /// If the other collider has a DamageDealer component, it applies the damage to the health points.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
            if (damage != null)
                HP.ApplyChange(-damage.DamageAmount);
        }
    }
}