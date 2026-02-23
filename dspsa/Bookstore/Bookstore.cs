using System;

namespace Bookstore
{
    public class BookStore
    {
        public string Name { get; set; }
        public string Location { get; set; }
        private List<Book> Books {get; set;}
        private List<Person> People { get; set; }

        public BookStore(string name, string location)
        {
            Name = name;
            Location = location;
            Books = new List<Book>();
            People = new List<Person>();
        }

        public BookStore(string name, string location, List<Book> books, List<Person> people)
        {
            Name = name;
            Location = location;
            Books = books;
            People = people;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
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

        public List<Customer> GetCustomers()
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
            string s = $"Bookstore {Name} in {Location}\n";
            s += $"Inventory count: {Books.Count}\n";
            foreach (var book in Books)
            {
                s += $"- {book}\n";
            }

            var customers = GetCustomers();
            var staff = GetStaff();

            s += $"\nSTAFF:\n";
            s += $"Staff count: {staff.Count}\n";
            foreach (var staffmember in staff)
            {
                s += $"- {staffmember}\n";
            }

            s += $"\nCUSTOMERS:\n";
            s += $"Customer count: {customers.Count}\n";
            foreach (var customer in customers)
            {
                s += $"- {customer}\n";
            }

            return s.ToString();

        }


    }





    public enum Genre
    {
        Horror,
        Romance,
        Adventure,
        Detective,
        Thriller,
        SelfHelp,
        Science,
        History,
        Fantasy,
        Biography,
        NonFiction
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public Genre Category { get; set; }
        public int Stock { get; set; }

        public Book(string title, string author, string edition, double price, int pages,
        Genre category, int stock)
        {
            Title = title;
            Author = author;
            Edition = edition;
            Price = price;
            Pages = pages;
            Category = category;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"Book: {Title} - Price: {Price} - Amount in stock: {Stock}";
        }
    }

    public class Customer: Person
    {
        public string Phonenumber { get; set; }

        public Customer(string name, DateOnly birthday, char gender, string email, 
        string phonennumber) : base(name, birthday, gender, email)
        {
            Phonenumber = phonennumber;
        }

        public override string ToString()
        {
            return $"Customer {Name}: {Phonenumber} / {Email}";
        }
    }

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
        Seller,
        DataScientist,
        OWNER
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