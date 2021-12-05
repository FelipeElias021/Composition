using System;

namespace Composition1_csharp.Entities
{
    internal class Department
    {
        public string Name { get; set; }


        public Department()
        {
        }

        public Department(string name)
        {
            Name = name;
        }
    }
}
