using UnityEngine;
using TMPro;

namespace ScriptableArchitect.Elements
{
    /// <summary>
    /// This class represents an elemental entity in the game.
    /// </summary>
    public class Elemental : MonoBehaviour
    {
        /// <summary>
        /// The element represented by this elemental.
        /// </summary>
        [Tooltip("Element represented by this elemental.")]
        public AttackElement Element;
        /// <summary>
        /// The text component to display the name of the element.
        /// </summary>
        [Tooltip("Text to fill in with the element name.")]
        public TMP_Text ComponentLabel;
        /// <summary>
        /// This method is called when the script instance is being loaded.
        /// It sets the text of the Label to the name of the Element.
        /// </summary>
        private void OnEnable()
        {
            if (ComponentLabel != null)
                ComponentLabel.text = Element.name;
        }
        /// <summary>
        /// This method is called when the Collider other enters the trigger.
        /// It checks if the other collider also has an Elemental component and if its Element is in the defeated elements of this Elemental's Element.
        /// If so, it destroys this game object.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            Elemental e = other.gameObject.GetComponent<Elemental>();
            if (e != null)
            {
                if (e.Element.DefeatedElements.Contains(Element))
                    Destroy(gameObject);
            }
        }
    }
}