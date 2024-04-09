using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableArchitect.Variables
{
    [CreateAssetMenu(menuName = "ScriptableArchitect/Variables/StringVariable")]
    public class StringVariable : ValueAsset<string>
    {
    }
}