using TMPro;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    public class  InputFieldSetter : MonoBehaviour
    {
        [SerializeField] TMP_InputField InputField;
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