using System;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class ToolBeltAttribute : Attribute
    {
        public string ButtonLabel { get; private set; }
        public int GroupId { get; private set; }

        public ToolBeltAttribute(string buttonLabel = "Action", int groupId = 0)
        {
            ButtonLabel = buttonLabel;
            GroupId = groupId;
        }
    }
}