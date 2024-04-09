using UnityEngine;

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// This class represents an AnimationCurve variable that can be created as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableArchitect/Animation/AnimationCurveVariable")]
    public class AnimationCurveVariable : ValueAsset<AnimationCurve>
    {
    }
}