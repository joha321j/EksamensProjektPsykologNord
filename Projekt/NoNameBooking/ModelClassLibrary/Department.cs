namespace ModelClassLibrary
{
    public class Department
    {
        public string Name { get; set; }
        public string Address { get; }

        public Department(string name, string address)
        {
            Name = name;
            Address = address;
        }


    }
}