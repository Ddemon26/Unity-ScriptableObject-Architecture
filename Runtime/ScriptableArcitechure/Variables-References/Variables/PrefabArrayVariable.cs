using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a Prefab array variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/GameObject/PrefabArrayVariable")]
    public class PrefabArrayVariable : ArrayVariable<GameObject>
    {
    }
}