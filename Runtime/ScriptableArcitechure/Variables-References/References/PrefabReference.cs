using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class PrefabReference : ValueReference<GameObject, PrefabVariable>
    {
        public PrefabReference() { }

        public PrefabReference(GameObject value) : base(value) { }
    }
}