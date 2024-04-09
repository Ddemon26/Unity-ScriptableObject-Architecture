using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class ColorArrayReference : ValueReference<Color[], ColorArrayVariable>
    {
        public ColorArrayReference() { }
        
        public ColorArrayReference(Color[] value) : base(value) { }
    }
}