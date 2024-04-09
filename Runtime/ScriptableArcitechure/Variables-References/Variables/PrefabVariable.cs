using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a prefab variable that can be created as a ScriptableObject.
    /// Note: This can only deal with prefabs and not live GameObjects.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/GameObject/PrefabVariable")]
    public class PrefabVariable : ValueAsset<GameObject>
    {
    }
}