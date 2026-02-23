using System;
using System.Collections.Generic;

namespace PCWinkel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Klant Pilar = new Klant("Pilar", "Boom", new DateOnly(2007, 04, 26)
            , "pilar@outlook.com", "+32476897251");
            Klant Thomas = new Klant("Thomas", "Antwerpen", new DateOnly(2005, 01, 14),
            "outlook", "+32897653262");
            Klant Jente = new Klant("Jente", "Kapelle-Op-den-Bos", new DateOnly(2005, 09, 01),
            "Jente@gmail.com", "+3234673486");

            Personeelslid Romeo = new Personeelslid("Romeo", "Charleroi", new DateOnly(2006, 05, 17)
            , Job.Gooner);
            Personeelslid Romeo2 = new Personeelslid("Romeo2", "Zimbabwe", new DateOnly(1973, 02, 14)
            , Job.ZimmerMan);
            Personeelslid RomeoEpsteinLover = new Personeelslid("Romeo <3 Epstein", "THE ISLAND",
            new DateOnly(2026, 02, 16), Job.Gluesniffer);

            PC Asusblaster2000 = new PC("Asusblaster2000", Merk.Asus, 
            new Dictionary<Onderdeel, string>{{Onderdeel.GPU, "1080ti"}, 
            {Onderdeel.RAM, "4GB"}, {Onderdeel.PowerSupply, "600W"}, 
            {Onderdeel.SSD, "12TB"}}, 3882.99, 15);

            PC ProBook85 = new PC("ProBook85", Merk.Starforge, 
            new Dictionary<Onderdeel, string>{{Onderdeel.GPU, "5090"}, 
            {Onderdeel.RAM, "128GB"}, {Onderdeel.PowerSupply, "1200W"}, 
            {Onderdeel.SSD, "20TB"}}, 10000.67, 3);

            pcwinkel Alternate = new pcwinkel("Alternate", "Wilrijk");
            Alternate.BouwPC(Asusblaster2000);
            Alternate.BouwPC(ProBook85);
            Alternate.VoegPersoonToe(Pilar);
            Alternate.VoegPersoonToe(Thomas);
            Alternate.VoegPersoonToe(Jente);
            Alternate.VoegPersoonToe(Romeo);
            Alternate.VoegPersoonToe(Romeo2);
            Alternate.VoegPersoonToe(RomeoEpsteinLover);

            Console.WriteLine(Alternate);



        }
    }
}