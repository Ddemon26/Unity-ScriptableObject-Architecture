using System.Collections.Generic;

namespace ScriptableArchitect.Editor
{
    public class ToolBeltGroup
    {
        public int GroupId { get; set; }
        public List<string> FieldNames { get; set; }
        public bool IsVisible { get; set; }

        public ToolBeltGroup(int groupId)
        {
            GroupId = groupId;
            FieldNames = new List<string>();
        }
    }
}