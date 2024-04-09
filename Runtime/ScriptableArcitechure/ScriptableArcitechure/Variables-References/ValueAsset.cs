using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect
{
    public abstract class ValueAsset<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [Tooltip("Description of the variable, only visible in the Unity editor.")]
        public string developerDescription = "";
#endif
        public T value;
        public T Value
        {
            get => value;
            set => this.value = value;
        }
        public virtual void SetValue(T refValue) => Value = refValue;
        public virtual void SetValue(ValueAsset<T> refValue) => Value = refValue.Value;
        public static implicit operator T(ValueAsset<T> asset) => asset.Value;
    }
}