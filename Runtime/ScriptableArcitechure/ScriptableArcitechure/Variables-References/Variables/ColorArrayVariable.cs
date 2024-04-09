using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents an array of Color variables that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Material/ColorArrayVariable")]
    public class ColorArrayVariable : ArrayVariable<Color>
    {
    }
}