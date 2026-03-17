using System;

namespace Ziekenhuis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Verpleegster Romeo = new Verpleegster(new DateOnly(2006, 05, 17), "O-", "Romeo Heylen", "Mechelen", Departement.MentaalOnstabieleBejaarden);
            Dokter Pilar = new Dokter(new DateOnly(2007, 04, 26), "GeenIdee", "Pilar Switsers", "Boom", "Organenhandel", "Organen en donaties");
            Patiënt Kobe = new Patiënt(new DateOnly(2007, 03, 12), "GeenIdee", "Kobe Marquebreucq", "Weerde", "Arm gebroken", "Hooikoorts", "Gips", 3, "Pijnstillers");
            Patiënt Guillaume = new Patiënt(new DateOnly(1996, 11, 28), "A+", "Guillaume De Smedt","Mechelen", "Hersenbloeding", "Pinda's", "Plakker na operatie", 10, "Immodium");
            Patiënt Anthony = new Patiënt(new DateOnly(1995, 07, 31), "A-", "Anthony Coppens", "Hoboken", "Enlargement van iets", "Muggen", "+3cm", 10, "Dafalgan");
            Verpleegster Daan = new Verpleegster(new DateOnly(2005, 05, 18), "GeenIdee", "Daan Moerenhout", "Datacenter", Departement.FanRoom);
            Persoon John = new Persoon();
            Verpleegster Collin = new Verpleegster(new DateOnly(1991, 04, 16), "GeenIdee", "Collin Van der Vorst", "SQLWorkbench", Departement.Spreadsheets);
            Dokter Elke = new Dokter(new DateOnly(1980, 04, 23), "GeenIdee", "Elke Boonen", "Script", "Master in IT kennis", "Scripts reviven");

            List<Persoon> mensen = new List<Persoon>{Romeo, Pilar, Kobe, Guillaume, Anthony, Daan, John, Collin, Elke};
            //mensen.Add(Anthony);

            Ziekenhuis SintMaarten = new Ziekenhuis("Sint-Maarten", "Mechelen", mensen);

            Dokter Redouane = new Dokter(new DateOnly(2004, 06, 25), "O-", "Redouane", "Nekkerspoel", "Hartchirurgie", "Harttransplantaties");
            SintMaarten.VoegToe(Redouane);

            Console.WriteLine(SintMaarten);


        }
    }
}