#region Using directives
using System;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class GlobID
    {
        public GlobID() : this(Guid.NewGuid(), "", "") { }
        public GlobID(string name, string description) : this(Guid.NewGuid(), name, description) { }
        public GlobID(Guid guid, string name, string description)
        {
            IGuid = guid;
            Name = name;
            Description = description;
        }
        public Guid IGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void SetNameDesc(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public override string ToString()
        {
            return string.Format("Guid = {0}\nName = {1}\nDescription = {2}", IGuid, Name, Description);
        }
    }
}
