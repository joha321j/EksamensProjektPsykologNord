using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class RoomView
    {
        public int Id { get; }
        public string Name { get; }

        public RoomView(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
