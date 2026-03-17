using System;

namespace Hospital
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
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

        public Person(int id, string name, DateOnly birthday, char gender)
        {
            ID = id;
            Name = name;
            Birthday = birthday;
            Gender = gender;
        }

        public Person(int id, string name, DateOnly birthday)
        {
            ID = id;
            Name = name;
            Birthday = birthday;
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
        private Data data = new Data();
        public Spec Specialty { get; set; }
        public Doctor(string name, DateOnly birthday,char gender, Spec specialty): base(name, birthday, gender)
        {
            Specialty = specialty;
            ID = data.InsertDoctor(this);
        }
        public Doctor(int id, string name, DateOnly birthday, char gender, Spec specialty) : base(id, name, birthday, gender)
        {
            Specialty = specialty;
        }
        public Doctor(int id, string name, DateOnly birthday, Spec specialty) : base(id, name, birthday)
        {
            Specialty = specialty;
        }
        public override string ToString()
        {
            return $"{Name} - {ID} -  is specialised in {Specialty}";
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
        private Data data = new Data();
        public Dep Department { get; set; }
        public Nurse(string name, DateOnly birthday,char gender, Dep department): base(name, birthday, gender)
        {
            Department = department;
            ID = data.InsertNurse(this);
        }
        public Nurse(int id, string name, DateOnly birthday, char gender, Dep department) : base(id, name, birthday, gender)
        {
            Department = department;
        }
        public Nurse(int id, string name, DateOnly birthday, Dep department) : base(id, name, birthday)
        {
            Department = department;
        }
        public override string ToString()
        {
            return $"{Name} - {ID} -  is currently located in {Department}";
        }
    }

    public class Patient: Person
    {
        private Data data = new Data();
        public string Problem { get; set; }
        public string Solution { get; set; }

        public Patient(string name, DateOnly birthday,char gender, string problem, string solution): base(name, birthday, gender)
        {
            Problem = problem;
            Solution = solution;
            ID = data.InsertPatient(this);
        }
        public Patient(int id, string name, DateOnly birthday, char gender, string problem, string solution) : base(id, name, birthday, gender)
        {
            Problem = problem;
            Solution = solution;
        }
        public Patient(int id, string name, DateOnly birthday, string problem, string solution) : base(id, name, birthday)
        {
            Problem = problem;
            Solution = solution;
        }
        public override string ToString()
        {
            return $"Patient {ID} -  {Name} - Age: {Age} has the following problem: {Problem} and suggested to him is: {Solution}";
        }
    }

}