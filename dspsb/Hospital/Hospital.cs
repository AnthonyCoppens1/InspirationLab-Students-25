using System;

namespace Hospital
{
    public class Hospital
    {
        private Data data = new Data();
        public int ID { get; set; }
        public string Name {get; set;}
        public string Location {get; set;}

        public Hospital(string name, string location)
        {
            Name = name;
            Location = location;
            ID = data.InsertHospital(this);
        }

        public Hospital(string name, string location, List<Person> people)
        {
            Name = name;
            Location = location;
            ID = data.InsertHospital(this, people);
        }

        public void AddPerson(Person person)
        {
            data.AddPeopleToHospital(person.ID, this.ID);
        }

        /*public List<Patient> GetPatients()
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
        }*/

        public override string ToString()
        {
            string s = $"HOSPITAL {ID}: {Name}\n";
            /*foreach(Person person in People)
            {
                s += $"*{person}\n";
            }*/
            return s;
        }

    }
}