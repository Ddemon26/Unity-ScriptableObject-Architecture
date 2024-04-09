using UnityEngine;

namespace ScriptableArchitect.Variables
{
    public abstract class ArrayVariable<T> : ValueAsset<T[]>
    {
        public T GetValue(int index)
        {
            if (index < 0 || index >= value.Length)
            {
                Debug.LogWarning("Index out of range, returning first element in array.");
                return value[0];
            }
            return value[index];
        }
    }
}