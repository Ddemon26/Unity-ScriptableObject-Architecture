using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a ScriptableObject variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Testing/ScriptableObjectVariable")]
    public class ScriptableObjectVariable : ValueAsset<ScriptableObject>
    {
    }
}