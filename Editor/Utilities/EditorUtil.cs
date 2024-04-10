using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Editor
{
    public static class EditorUtil
    {
        public static void MarkHolderAsDirty(Object holder)
        {
            EditorUtility.SetDirty(holder);
        }
        
        public static void DrawGroupButton(ToolBeltGroup group, ref int buttonCount)
        {
            if (buttonCount != 0 && buttonCount % 5 == 0)
            {
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
            }

            var prefsKey = $"ToolBeltGroupVisibility_{group.GroupId}";
            group.IsVisible = EditorPrefs.GetBool(prefsKey, false);

            GUI.backgroundColor = group.IsVisible ? Color.green : Color.gray;
            if (GUILayout.Button(group.IsVisible ? $"Hide {group.GroupId}" : $"Show {group.GroupId}"))
            {
                group.IsVisible = !group.IsVisible;
                EditorPrefs.SetBool(prefsKey, group.IsVisible);
            }
            buttonCount++;
        }
    }
}