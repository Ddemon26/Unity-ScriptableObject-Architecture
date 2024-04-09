using UnityEngine;

namespace ScriptableArchitect.Variables
{
    [System.Serializable]
    public class ColorReference : ValueReference<Color, ColorVariable>
    {
        public ColorReference() { }

        public ColorReference(Color value) : base(value) { }
    }
}