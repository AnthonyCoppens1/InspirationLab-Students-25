using System;

namespace Ziekenhuis
{
    public enum Departement
    {
        MentaalOnstabieleBejaarden, 
        FanRoom,
        FysiekGehandicapteBejaarden,
        Pediatrie,
        Gynaecologie,
        Spoed,
        Oncologie,
        Psychiatrie,
        Spreadsheets
    }


    public class Dokter: Persoon
    {
        private Data data = new Data();
        public string Diploma { get; set; }
        public string Specialiteit { get; set; }

        public Dokter(DateOnly geboortedatum, string bloedtype, string naam, string adres, string diploma, string specialiteit): base(geboortedatum, bloedtype, naam, adres)
        {
            Diploma = diploma;
            Specialiteit = specialiteit;
            ID = data.InsertDokter(this);
        }
        public Dokter(int id, DateOnly geboortedatum, string bloedtype, string naam, string adres, 
            string diploma, string specialiteit) : base(id, geboortedatum, bloedtype, naam, adres)
        {
            Diploma = diploma;
            Specialiteit = specialiteit;
        }

        public Dokter(int id, DateOnly geboortedatum, string naam, string specialiteit) : base(id, geboortedatum, naam)
        {
            Specialiteit = specialiteit;
        }
        public override string ToString()
        {
            return $"Dokter {ID}: {Naam}, specialisatie {Specialiteit}, heeft destijds IETS gestudeerd\n";
        }
    }

    public class Patiënt: Persoon
    {
        private Data data = new Data();
        public string Reden { get; set; }
        public string Allergie { get; set; }
        public string Oplossing { get; set; }
        public int Urgentie { get; set; } //schaal van 1 - 10
        public string Medicatie { get; set; }

        public Patiënt(DateOnly geboortedatum, string bloedtype, string naam, string adres, string reden, string allergie, string oplossing, int urgentie, string medicatie): base(geboortedatum, bloedtype, naam, adres)
        {
            Reden = reden;
            Allergie = allergie;
            Oplossing = oplossing;
            Urgentie = urgentie;
            Medicatie = medicatie;
            ID = data.InsertPatient(this);
        }

        public Patiënt(int id, DateOnly geboortedatum, string bloedtype, string naam, string adres, 
            string reden, string allergie, string oplossing, int urgentie, string medicatie) : 
            base(id, geboortedatum, bloedtype, naam, adres)
        {
            Reden = reden;
            Allergie = allergie;
            Oplossing = oplossing;
            Urgentie = urgentie;
            Medicatie = medicatie;
        }

        public Patiënt(int id, DateOnly geboortedatum, string naam, string reden, string oplossing) : base(id, geboortedatum, naam)
        {
            Reden = reden;
            Oplossing = oplossing;
        }

        public override string ToString()
        {
            return $"PATIËNT {ID}: {Naam} - Leeftijd: {Leeftijd}\n- Reden: {Reden} - Oplossing: {Oplossing}\n- Pas op voor: WASBEREN\n";
        }
    }

    public class Verpleegster: Persoon
    {
        private Data data = new Data();
        public Departement Afdeling { get; set; }

        public Verpleegster(DateOnly geboortedatum, string bloedtype, string naam, string adres, Departement afdeling): base(geboortedatum, bloedtype, naam, adres)
        {
            Afdeling = afdeling;
            ID = data.InsertVerpleegster(this);
        }

        public Verpleegster(int id, DateOnly geboortedatum, string bloedtype, string naam, string adres, 
            Departement afdeling) : base(id, geboortedatum, bloedtype, naam, adres)
        {
            Afdeling = afdeling;
        }
        public Verpleegster(int id, DateOnly geboortedatum, string naam, Departement afdeling) : base(id, geboortedatum, naam)
        {
            Afdeling = afdeling;
        }

        public override string ToString()
        {
            return $"Verpleegster {ID}: {Naam}, werkt in {Afdeling}, is {Leeftijd} jaar oud en woont in ZIMBABWE\n";
        }
    }

    public class Persoon
    {
        public int ID { get; set; }
        //prop + tab voor shortcut nieuwe property
        public DateOnly Geboortedatum { get; set; }
        public string Bloedtype { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public int Leeftijd { get {return BerekenLeeftijd();} }

        //ctor + tab voor constructor
        public Persoon()
        {
            Geboortedatum = new DateOnly(2000, 01, 01);
            Bloedtype = "O-";
            Naam = "John Doe";
            Adres = "Paddengatstraat 33, 2810 Willebroek";
        }

        public Persoon(int id, DateOnly geboortedatum, string naam)
        {
            Geboortedatum = geboortedatum;
            Naam = naam;
            ID = id;
        }

        public Persoon(DateOnly geboortedatum, string bloedtype, string naam, string adres)
        {
            Geboortedatum = geboortedatum;
            Bloedtype = bloedtype;
            Naam = naam;
            Adres = adres;
        }

        public Persoon(int id, DateOnly geboortedatum, string bloedtype, string naam, string adres)
        {
            Geboortedatum = geboortedatum;
            Bloedtype = bloedtype;
            Naam = naam;
            Adres = adres;
            ID = id;
        }

        /*public void Print()
        {
            Console.WriteLine($"{Naam} - {Adres}");
        }*/

        public override string ToString()
        {
            return $"{Naam} - {Adres}";
        }

        private int BerekenLeeftijd()
        {
            DateTime nu = DateTime.Now;
            int leeftijd = nu.Year - Geboortedatum.Year;
            if (nu.Year < Geboortedatum.Year + leeftijd)
            {
                leeftijd--;
            }
            return leeftijd;
        }

    }
}