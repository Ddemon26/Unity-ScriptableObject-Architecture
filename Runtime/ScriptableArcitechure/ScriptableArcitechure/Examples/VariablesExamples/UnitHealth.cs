using UnityEngine;
using UnityEngine.Events;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a unit with health points in the game.
    /// It also handles damage and death events.
    /// </summary>
    [AddComponentMenu("Scriptable Architect/Variables/Examples/Unit Health")]
    [HelpURL("https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=2132s")]
    public class UnitHealth : MonoBehaviour
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
        /// The event that is invoked when the unit takes damage.
        /// </summary>
        [Tooltip("The event that is invoked when the unit takes damage.")]
        public UnityEvent DamageEvent;

        /// <summary>
        /// The event that is invoked when the unit dies.
        /// </summary>
        [Tooltip("The event that is invoked when the unit dies.")]
        public UnityEvent DeathEvent;

        /// <summary>
        /// Flag to check if the unit is dead.
        /// </summary>
        private bool isDead = false;

        /// <summary>
        /// Start is called before the first frame update.
        /// If ResetHP is true, it sets the health points to the starting health points.
        /// </summary>
        private void Start()
        {
            if (ResetHP)
            {
                HP.SetValue(StartingHP);
                isDead = false;
            }
        }

        /// <summary>
        /// This method is called when the Collider other enters the trigger.
        /// If the other collider has a DamageDealer component, it applies the damage to the health points and invokes the DamageEvent.
        /// If the health points are less than or equal to zero, it invokes the DeathEvent.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (isDead) return;

            if (other.gameObject.TryGetComponent<DamageDealer>(out var damage))
            {
                ApplyDamage(damage.DamageAmount);
            }
        }

        /// <summary>
        /// Applies damage to the unit, invokes the DamageEvent, and checks if the unit is dead.
        /// If the unit is dead, it invokes the DeathEvent.
        /// </summary>
        /// <param name="damageAmount">The amount of damage to apply.</param>
        private void ApplyDamage(float damageAmount)
        {
            HP.ApplyChange(-damageAmount);
            DamageEvent.Invoke();

            if (HP.Value <= 0.0f && !isDead)
            {
                DeathEvent.Invoke();
                isDead = true;
            }
        }
    }
}