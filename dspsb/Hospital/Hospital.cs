using System;

namespace Hospital
{
    public class Hospital
    {
        public string Name {get; set;}
        public string Location {get; set;}
        private List<Person> People {get; set;}

        public Hospital(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public Hospital(string name, string location, List<Person> people)
        {
            Name = name;
            Location = location;
            People = people;
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            foreach (var person in People)
            {
                if (person is Patient)
                {
                    patients.Add((Patient)person);
                }
            }

            return patients;
        }

        public List<Person> GetPersonel()
        {
            List<Person> personel = new List<Person>();
            foreach(var person in People)
            {
                if (person is Doctor || person is Nurse)
                {
                    personel.Add(person);
                }
            }
            return personel;
        }

        public override string ToString()
        {
            string s = $"HOSPITAL: {Name}\n";
            foreach(Person person in People)
            {
                s += $"*{person}\n";
            }
            return s;
        }

    }
}