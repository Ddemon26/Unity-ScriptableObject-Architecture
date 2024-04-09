using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class MaterialArrayReference : ValueReference<Material[], MaterialArrayVariable>
    {
        public MaterialArrayReference() { }

        public MaterialArrayReference(Material[] value) : base(value) { }
    }
}