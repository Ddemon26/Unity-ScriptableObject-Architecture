using UnityEngine;
using TMPro;
using KBCore.Refs;

namespace ScriptableArchitect.Variables
{
    public class  InputFieldSetter : ValidatedMonoBehaviour
    {
        [SerializeField, Self] TMP_InputField InputField;
        [SerializeField] FloatVariable Variable;
        [SerializeField] bool UpdateVariableOnEndEdit = true;

        private void Update()
        {
            if (InputField != null && Variable != null)
                InputField.text = Variable.Value.ToString();
        }

        public void OnEndEdit(FloatVariable value)
        {
            if (UpdateVariableOnEndEdit)
                Variable.SetValueWithClamp(value.Value);
        }
    }
}