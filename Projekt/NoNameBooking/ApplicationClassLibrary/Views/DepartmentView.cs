using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class DepartmentView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentView(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
