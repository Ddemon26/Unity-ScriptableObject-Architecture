using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class PrefabArrayReference : ValueReference<GameObject[], PrefabArrayVariable>
    {
        public PrefabArrayReference() { }

        public PrefabArrayReference(GameObject[] value) : base(value) { }
    }
}