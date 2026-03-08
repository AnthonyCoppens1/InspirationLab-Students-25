using System;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor Anthony = new Doctor("Anthony Coppens", new DateOnly(1995, 07, 31), 'M', Spec.Cardiovascular);
            Doctor Harkirat = new Doctor("Harkirat Dhanoa", new DateOnly(2006, 09, 23), 'M', Spec.Cardiologist);
            Person John = new Person();
            Nurse Joseph = new Nurse("Joseph Duku", new DateOnly(2004, 10, 11), 'M', Dep.TheEYEDepartement);
            Nurse Milton = new Nurse("Milton Tahlah", new DateOnly(2005, 06, 21), 'M', Dep.WeirdERSituations);
            Patient Alvaro = new Patient("Alvaro Ibor Ferrer", new DateOnly(2004, 12, 11), 'M', "Mental Illness", "Therapist");
            Patient Namariq = new Patient("Namariq Sachit", new DateOnly(2006, 10, 09), 'F', "Lost an arm and broken leg", "Impossible to save");
            Patient Frieda = new Patient("Frieda Kroket", new DateOnly(1990, 08, 20), 'F', "Addicted to krokets", "Weight loss camp");
            //BE CAREFULL WITH SPELLING MISTAKES OR DIFFERENT CAPITALIZATION, CAUSES DIFFERENT ROLES

            Console.WriteLine(Milton.Gender);

            John.Name = "Johanna";
            John.Gender = 'X';

            Console.WriteLine(Alvaro);

            List<Person> people = new List<Person>(){Anthony, Harkirat, John, Joseph, Milton, Alvaro, Namariq, Frieda};
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine($"--------------------------------------------------\n");
            Patient Usman = new Patient("Usman", new DateOnly(2000, 04, 14), 'X', "Cardiovascular artery disease", "Surgery, and a lot of it!");
            Hospital SintMaarten = new Hospital("Sint Maarten", "Mechelen", people);

            SintMaarten.AddPerson(Usman);
            Console.WriteLine(SintMaarten);
        }
    }
}