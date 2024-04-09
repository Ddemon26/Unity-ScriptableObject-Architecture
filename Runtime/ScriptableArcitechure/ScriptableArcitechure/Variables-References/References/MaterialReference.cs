using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class MaterialReference : ValueReference<Material, MaterialVariable>
    {
        public MaterialReference() { }

        public MaterialReference(Material value) : base(value) { }
    }
}