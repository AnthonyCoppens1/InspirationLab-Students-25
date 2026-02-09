using System;

namespace Bookstore
{
    public class Staff: Person
    {
        public Role Position { get; set; }

        public Staff(string name, DateOnly birthday, char gender, 
        string email, Role position) : base(name, birthday, gender, email)
        {
            Position = position;
        }

        public override string ToString()
        {
            return $"STAFF: {Name} - {Position}";
        }
    }

    public enum Role
    {
        Manager,
        Cleaner,
        Secretary,
        Supervisor,
        Refiller,
        Seller
    }





    public class Person
    {
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }

        public Person(string name, DateOnly birthday, char gender, string email)
        {
            Name = name;
            Birthday = birthday;
            Gender = gender;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name} - {Birthday}";   
        }
        
    }
}