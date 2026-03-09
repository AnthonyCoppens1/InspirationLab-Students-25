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

        
        public override string ToString()
        {
            string s = $"HOSPITAL: {Name}\n";
            return s;
        }

    }
}