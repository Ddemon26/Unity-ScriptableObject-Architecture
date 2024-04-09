using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class LayerMaskReference : ValueReference<LayerMask, LayerMaskVariable>
    {
        public LayerMaskReference() { }

        public LayerMaskReference(LayerMask value) : base(value) { }
    }
}