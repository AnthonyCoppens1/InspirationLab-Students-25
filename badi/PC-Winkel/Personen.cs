using System;

namespace PCWinkel
{
    public class Persoon
    {
        public string Naam { get; set; }
        public string Adres { get; set; }
        public DateOnly Geboortedatum { get; set; }

        public Persoon(string naam, string adres, DateOnly geboortedatum)
        {
            Naam = naam;
            Adres = adres;
            Geboortedatum = geboortedatum;
        }

        public Persoon(string naam)
        {
            Naam = naam;
        }

        public override string ToString()
        {
            return $"Naam: {Naam} - Geboren: {Geboortedatum}";
        }
    }

    public class Klant : Persoon
    {
        public string Email { get; set; }
        protected string Telefoon { get; set; }

        public Klant(string naam,string adres, DateOnly geboortedatum, string email, 
        string telefoon) : base(naam, adres, geboortedatum)
        {
            Email = email;
            Telefoon = telefoon;
        }

        public Klant(string naam, string email, string telefoon) : base(naam)
        {
            Email = email;
            Telefoon = telefoon;
        }

        public override string ToString()
        {
            return $"KLANT: {Naam} / Geboortedatum: {Geboortedatum} / Email: {Email}";
        }
    }

    public enum Job
    {
        Cassier,
        CEO,
        Vakkenvuller,
        Bouwer,
        Marketing,
        Gluesniffer,
        Manager,
        Gooner,
        PoetsvrouwOfMan,
        ProfessioneleSlacker,
        ZimmerMan
    }

    public class Personeelslid: Persoon
    {
        public Job Functie { get; set; }

        public Personeelslid(string naam, string adres, DateOnly geboortedatum, 
        Job functie) : base(naam, adres, geboortedatum)
        {
            Functie = functie;
        }

        public override string ToString()
        {
            return $"Personeelslid: {Naam}, Geboortedatum: {Geboortedatum}, Job: {Functie}";
        }
        
    }
}