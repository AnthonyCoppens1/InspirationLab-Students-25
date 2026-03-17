using System;

namespace Ziekenhuis
{
    public class Ziekenhuis
    {
        private Data data = new Data();
        public int ID { get; set; }
        public List<Persoon> Personen { get; private set; }
        public string Naam { get; set; }
        public string Adres { get; set; }

        public Ziekenhuis(string naam, string adres)
        {
            Naam = naam;
            Adres = adres;
            Personen = new List<Persoon>();
            ID = data.InsertZiekenhuis(this);
        }

        public Ziekenhuis(string naam, string adres, List<Persoon> personen)
        {
            Naam = naam;
            Adres = adres;
            Personen = personen;
            ID = data.InsertZiekenhuis(this, personen);
        }

        public Ziekenhuis(int id, string naam, string adres, List<Persoon> personen)
        {
            Naam = naam;
            Adres = adres;
            Personen = personen;
            ID = id;
        }

        public void VoegToe(Persoon p)
        {
            data.voegMensenToeAanZiekenhuis(p.ID, this.ID);
        }

        public List<Patiënt> WieZijnMijnPatiënten()
        {
            return data.SelecteerPatienten(this.ID);
        }

        public List<Persoon> WieZijnMijnPersoneelsleden()
        {
            return data.SelecteerPersoneel(this.ID);
        }

        public override string ToString()
        {
            string s = $"ZIEKENHUIS: {Naam}\n";
            s += "------------\n";
            s += "PATIENTEN:\n";
            foreach (Persoon p in WieZijnMijnPatiënten())
            {
                s += $"- {p}\n";
            }
            s += "------------\n";
            s += "PERSONEEL:\n";
            foreach (Persoon p in WieZijnMijnPersoneelsleden())
            {
                s += $"- {p}\n";
            }
            return s;
        }

    }
}