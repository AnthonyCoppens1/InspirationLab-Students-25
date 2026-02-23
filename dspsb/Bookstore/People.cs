using System;

namespace BookStore
{
    public class Person
    {
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public string City { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }

        public Person(string name, DateOnly birthday, string city, char gender, string email)
        {
            Name = name;
            Birthday = birthday;
            City = city;
            Gender = gender;
            Email = email;
        }

        public Person(string name, DateOnly birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"Person {Name}";
        }
    }

    public enum Position
    {
        Manager,
        DeskPerson,
        JustStaffToKeepTheBook,
        Cashier,
        Technician,
        Cleaner,
        CEO,
        IT,
        DataScientist,
        BookGluer,
        Gluesniffer
    }

    public class Staff : Person
    {
        public Position Job { get; set; }
        public string Schedule { get; set; }

        /*public Staff(string name, DateOnly birthday, Position job, string schedule) : base(name, birthday)
        {
             AS YOU CAN SEE IT IS NOT MANDATORY TO INHERIT EVERYTHING, JUST NEED DIFFERENT CONSTRUCTOR IN PERSON
        }*/

        public Staff(string name, DateOnly birthday, string city, char gender, string email, 
        Position job, string schedule) : base(name, birthday, city, gender, email)
        {
            Job = job;
            Schedule = schedule;
        }

        public override string ToString()
        {
            return $"Staffmember: {Name} - Position: {Job}";
        }
    }

    public class Customer : Person
    {
        public string PhoneNumber { get; set; }

        public Customer(string name, DateOnly birthday, string city, char gender, string email, string phonenumber)
        : base(name, birthday, city, gender, email)
        {
            PhoneNumber = phonenumber;
        }

        public override string ToString()
        {
            return $"CUSTOMER: {Name} contact details: {PhoneNumber} / {Email}";
        }
    }

}