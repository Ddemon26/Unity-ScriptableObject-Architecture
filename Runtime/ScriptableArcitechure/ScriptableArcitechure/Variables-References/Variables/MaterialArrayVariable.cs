using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    [CreateAssetMenu(menuName = "ScriptableArchitect/Material/MaterialArrayVariable")]
    public class MaterialArrayVariable : ArrayVariable<Material>
    {
    }
}