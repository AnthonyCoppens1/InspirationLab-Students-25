using System;

namespace Bookstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer Alexei = new Customer("Alexei", new DateOnly(2007, 03, 27), 'm', "alexei@gmail.com", "+32478928172");
            Customer Rodrigo = new Customer("Rodrigo", new DateOnly(2001, 07, 16), 'm', "rodrigo@thomasmore.be", "+3478645321");
            Customer Anthony = new Customer("Anthony", new DateOnly(1995, 07, 31), 'm', "anthony.coppens@thomasmore.be", "+32476897210");
            
            Staff Elif = new Staff("Elif", new DateOnly(2004, 02, 09), 'f', "elif@something.something", Role.Supervisor);
            Staff Joseph = new Staff("Joseph", new DateOnly(2004, 10, 11), 'm', "josephBookstoreman@bookstore.book", Role.DataScientist);
            Staff Malaak = new Staff("Malaak", new DateOnly(2005, 08, 12), 'f', "malaakBookstoreOWNER@Owner.bestbookstore",Role.OWNER);

            Book TheRichestManInBabylon = new Book("The richest man in Babylon", "George Samuel Clason", "3rd",
            6.99, 144, Genre.NonFiction, 53);
            Book BreakfastWithParticles = new Book("Breakfast with particles", "Sonia Fernandez", "1st", 22.99, 300
            , Genre.Science, 32);
            Book WhatIf = new Book("What if?", "Randal Munroe", "2nd", 15.99, 200, Genre.Science, 7);

            BookStore StandaardBoekhandel = new BookStore("Standaard Boekhandel", "Mechelen");

            //adding all customers
            StandaardBoekhandel.AddPerson(Alexei);StandaardBoekhandel.AddPerson(Rodrigo);StandaardBoekhandel.AddPerson(Anthony);
            //adding all staff
            StandaardBoekhandel.AddPerson(Elif);StandaardBoekhandel.AddPerson(Joseph);StandaardBoekhandel.AddPerson(Malaak);
            //adding all books
            StandaardBoekhandel.AddBook(TheRichestManInBabylon); StandaardBoekhandel.AddBook(BreakfastWithParticles);
            StandaardBoekhandel.AddBook(WhatIf);

            Console.WriteLine(StandaardBoekhandel);


            Console.WriteLine("\n------------------\n");
            StandaardBoekhandel.RemovePerson(Anthony);
            
            foreach (Customer c in StandaardBoekhandel.GetCustomers())
            {
                Console.WriteLine(c);
            }
        }
    }
}