using System;

namespace Hospital
{
    public class Person
    {
        public string Name { get; set; }
        private DateOnly Birthday { get; set; }
        public char Gender { get; set; }
        public int Age { get {return CalculateAge();}}

        public Person()
        {
            Name = "John Doe";
            Birthday = new DateOnly(2000, 1, 1);
            Gender = 'M';
        }

        public Person(string name, DateOnly birthday, char gender)
        {
            Name = name;
            Birthday = birthday;
            Gender = gender;

        }

        private int CalculateAge()
        {
            DateTime now = DateTime.Now;
            int bd = Birthday.Year;
            int age = now.Year - bd;
            if (now.Year < bd + age)
            {
                age--;
            }
            return age;
        }

        public override string ToString()
        {
            return $"{Name} - {Gender} - Age: {Age}";
        }
    }

    public enum Spec
    {
        Cardiovascular,
        Cardiologist,
        Orthopedic,
        Geriatry,
        Dermatology,
        Gynaecology,
        Pediatry,
        Neurology

    }


    public class Doctor: Person
    {
        public Spec Specialty { get; set; }
        public Doctor(string name, DateOnly birthday,char gender, Spec specialty): base(name, birthday, gender)
        {
            Specialty = specialty;
        }

        public override string ToString()
        {
            return $"{Name} is specialised in {Specialty}";
        }
    }

    public enum Dep
    {
        WeirdERSituations,
        TheEYEDepartement,
        OldPeople,
        Babies,
        ER,
        DrunkStudents,
        DrugOverdose
    }

    public class Nurse: Person
    {
        public Dep Department { get; set; }
        public Nurse(string name, DateOnly birthday,char gender, Dep department): base(name, birthday, gender)
        {
            Department = department;
        }
        public override string ToString()
        {
            return $"{Name} is currently located in {Department}";
        }
    }

    public class Patient: Person
    {
        public string Problem { get; set; }
        public string Solution { get; set; }

        public Patient(string name, DateOnly birthday,char gender, string problem, string solution): base(name, birthday, gender)
        {
            Problem = problem;
            Solution = solution;
        }
        public override string ToString()
        {
            if (Gender == 'M')
            {
                return $"Patient {Name} - Age: {Age} has the following problem: {Problem} and suggested to him is: {Solution}";
            }
            else if (Gender == 'F')
            {
                return $"Patient {Name} - Age: {Age} has the following problem: {Problem} and suggested to her is: {Solution}";
            }
            else if (Gender == 'X')
            {
                return $"Patient {Name} - Age: {Age} has the following problem: {Problem} and suggested to them is: {Solution}";
            }
            else
            {
                return $"Unknown entitiy";
            }
        }
    }

}