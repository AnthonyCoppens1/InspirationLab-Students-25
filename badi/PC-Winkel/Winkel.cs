using System;

namespace PCWinkel
{
    public enum Onderdeel
    {
        CPU,
        GPU,
        Moederbord,
        RAM,
        PowerSupply,
        SSD,
        HDD,
        Koeling,
        Case
    }
    public enum Merk
    {
        Samsung,
        Apple,
        Asus,
        MSI,
        Starforge,
        Alienware,
        Razor,
        HP,
        Dell,
        Lenovo
    }
    public class PC
    {
        public Dictionary<Onderdeel,string> Parts { get; set; }
        public double Prijs { get; set; }
        public string Naam { get; set; }
        public Merk Merknaam { get; set; }
        public int Stock { get; set; }

        public PC(string naam, Merk merknaam, Dictionary<Onderdeel, string> parts, 
        double prijs, int stock)
        {
            Naam = naam;
            Merknaam = merknaam;
            Parts = parts;
            Prijs = prijs;
            Stock = stock;
        }

        public override string ToString()
        {
            string s = $"PC {Naam}:\n";
            foreach (var pair in Parts)
            {
                s += $"\t- {pair.Key}: {pair.Value}\n";
            }
            s += $"Merknaam: {Merknaam} / Prijs: {Prijs} / Stock: {Stock}";

            return s;
        }

    }


    public class pcwinkel
    {
        public string Naam { get; set; }
        public string Locatie { get; set; }
        private List<PC> Inventaris { get; set; }
        private List<Persoon> Mensen { get; set; }

        //NIEUWE WINKEL
        public pcwinkel(string naam, string locatie)
        {
            Naam = naam;
            Locatie = locatie;
            Inventaris = new List<PC>();
            Mensen = new List<Persoon>();
        }

        // BESTAANDE WINKEL, NIEUWE LOCATIE, BESTAAND KLANTENBESTAND EN ITEMS
        public pcwinkel(string naam, string locatie, List<PC> inventaris, 
        List<Persoon> mensen)
        {
            Naam = naam;
            Locatie = locatie;
            Inventaris = inventaris;
            Mensen = mensen;
        }
        
        public void BouwPC(PC pc)
        {
            Inventaris.Add(pc);
        }

        public void BreekPCAf(PC pc)
        {
            Inventaris.Remove(pc);
        }

        public void VoegPersoonToe(Persoon persoon)
        {
            Mensen.Add(persoon);
        }

        public List<Klant> ZoekKlankten()
        {
            List<Klant> klanten = new List<Klant>();
            foreach(Persoon persoon in Mensen)
            {
                if (persoon is Klant)
                {
                    klanten.Add((Klant)persoon);
                }
            }

            return klanten;
        }

        public List<Personeelslid> ZoekPersoneelslid()
        {
            List<Personeelslid> personeelsleden = new List<Personeelslid>();
            foreach(Persoon persoon in Mensen)
            {
                if (persoon is Personeelslid)
                {
                    personeelsleden.Add((Personeelslid)persoon);
                }
            }

            return personeelsleden;
        }

        public override string ToString()
        {
            string s = $"PCWINKEL: {Naam} in {Locatie}\n";
            s += $"Inventaris: {Inventaris.Count}\n";
            foreach (var pc in Inventaris)
            {
                s += $"* {pc}\n";
            }

            var klanten = ZoekKlankten();
            var personeelsleden = ZoekPersoneelslid();

            s += $"KLANTEN:\n";
            foreach (var klant in klanten)
            {
                s += $"- {klant}\n";
            }

            s += $"PERSONEELSLEDEN:\n";
            foreach (var personeelslid in personeelsleden)
            {
                s += $"- {personeelslid}\n";
            }

            return s;

        }

    }
}