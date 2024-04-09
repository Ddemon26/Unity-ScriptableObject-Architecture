using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents a LayerMask variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/GameObject/LayerMaskVariable")]
    public class LayerMaskVariable : ValueAsset<LayerMask>
    {
    }
}