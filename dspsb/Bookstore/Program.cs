using System;

namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Staff s = new Staff();
            Customer c = new Customer();

            Bookstore B = new Bookstore();

            B.AddPerson(s);
            B.AddPerson(c);
        }
    }
}