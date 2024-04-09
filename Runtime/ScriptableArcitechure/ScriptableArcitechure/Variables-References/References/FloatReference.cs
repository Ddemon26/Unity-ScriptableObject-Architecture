using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class FloatReference : ValueReference<float, FloatVariable>
    {
        public FloatReference() { }

        public FloatReference(float value) : base(value) { }
    }
}