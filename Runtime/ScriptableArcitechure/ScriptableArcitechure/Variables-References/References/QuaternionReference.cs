using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class QuaternionReference : ValueReference<Quaternion, QuaternionVariable>
    {
        public QuaternionReference() { }

        public QuaternionReference(Quaternion value) : base(value) { }
    }
}