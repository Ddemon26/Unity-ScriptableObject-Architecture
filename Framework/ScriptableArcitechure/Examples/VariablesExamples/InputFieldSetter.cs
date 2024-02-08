using UnityEngine;
using TMPro;
using KBCore.Refs;

namespace ScriptableArchitect.Variables
{
    public class  InputFieldSetter : ValidatedMonoBehaviour
    {
        [SerializeField, Self] TMP_InputField InputField;
        [SerializeField] FloatVariable Variable;

        private void Update()
        {
            if (InputField != null && Variable != null)
                InputField.text = Variable.Value.ToString();
        }
    }
}