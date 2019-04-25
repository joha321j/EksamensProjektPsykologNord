using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class Room
    {
        public string Name { get; set; }
        public Department Department { get; }

        public Room(string name, Department department)
        {
            Name = name;
            Department = department;
        }
    }
}
