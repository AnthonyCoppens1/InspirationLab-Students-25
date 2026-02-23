using System;

namespace BookStore

{
    public enum Genres
    {
        Romance,
        Action,
        Adventure,
        Fantasy,
        Fiction,
        NonFiction,
        Murim,
        Horror,
        Babystories,
        PG18,
        Science,
        SciFi,
        Cooking,
        Biography,
        DailyLife,
        SelfHelp
    }
    public enum Covers
    {
        Hard,
        Soft,
        Paperback,
        Audio,
        Digital
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public Genres Genre { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public Covers Cover { get; set; }

        public Book(string title, string author, int releaseyear, Genres genre, double price,
        int stock, Covers cover)
        {
            Title = title; Author = author; ReleaseYear = releaseyear;
            Genre = genre; Price = price; Stock = stock; Cover = cover;
        }

        public override string ToString()
        {
            return $"Book {Title}, written by {Author} / Price: {Price} - Stock: {Stock}";
        }
        
    }


    public class Bookstore
    {
        public string Name { get; set; }
        public string Location { get; set; }
        private List<Book> Inventory { get; set; }
        private List<Person> People { get; set; }

        public Bookstore(string name, string location)
        {
            Name = name;
            Location = location;
            Inventory = new List<Book>();
            People = new List<Person>();
        }

        public Bookstore(string name, string location, List<Book> inventory, List<Person> people)
        {
            Name = name;
            Location = location;
            Inventory = inventory;
            People = people;
        }

        public void AddBook(Book book)
        {
            Inventory.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Inventory.Remove(book);
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
        }

        public void RemovePerson(Person person)
        {
            People.Remove(person);
        }

        public List<Staff> GetStaff()
        {
            List<Staff> staff = new List<Staff>();
            foreach (Person person in People)
            {
                if (person is Staff)
                {
                    staff.Add((Staff)person);
                }
            }

            return staff;
        }

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            foreach (Person person in People)
            {
                if (person is Customer)
                {
                    customers.Add((Customer)person);
                }
            }

            return customers;
        }

        public override string ToString()
        {
            string s = $"Bookstore: {Name} in {Location}\n";
            
        }

    }
}