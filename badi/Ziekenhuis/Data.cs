using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using MySqlConnector;

namespace Ziekenhuis
{
    public class Data
    {
        private string verbindingString =
            "datasource = 127.0.0.1;" +
            "port = 3308; username = root; password = ;" +
            "database = ziekenhuis;";

        private const int _patient = 1;
        private const int _verpleegster = 2;
        private const int _dokter = 3;

        private int Insert(string query)
        {
            MySqlConnection verbinding = new MySqlConnection(verbindingString);
            MySqlCommand commandDatabank = new MySqlCommand(query, verbinding);

            try
            {
                verbinding.Open();
                int resultaat = commandDatabank.ExecuteNonQuery();
                return (int)commandDatabank.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int InsertPatient(Patiënt patiënt)
        {
            string query = $"INSERT INTO person(ID, Name, Birth, Type, Problem, Treatment)" +
                $"VALUES(NULL, '{patiënt.Naam}', '{patiënt.Geboortedatum.ToString("yyyy-MM-dd")}'," +
                $"{_patient}, '{patiënt.Reden}', '{patiënt.Oplossing}');";

            return this.Insert(query);
        }

        public int InsertVerpleegster(Verpleegster verpleegster)
        {
            string query = $"INSERT INTO person(ID, Name, Birth, Type, Area)" +
                $"VALUES(NULL, '{verpleegster.Naam}', '{verpleegster.Geboortedatum.ToString("yyyy-MM-dd")}'," +
                $"{_verpleegster}, '{verpleegster.Afdeling}');";

            return this.Insert(query);
        }

        public int InsertDokter(Dokter dokter)
        {
            string query = $"INSERT INTO person(ID, Name, Birth, Type, Specialty)" +
                $"VALUES(NULL, '{dokter.Naam}', '{dokter.Geboortedatum.ToString("yyyy-MM-dd")}'," +
                $"{_dokter}, '{dokter.Specialiteit}');";

            return this.Insert(query);
        }

        //voegMensenToeAanZiekenhuis
        public int InsertZiekenhuis(Ziekenhuis ziekenhuis)
        {
            string query = $"INSERT INTO hospital(ID, Name) VALUES(NULL, '{ziekenhuis.Naam}');";
            return this.Insert(query);
        }

        public void voegMensenToeAanZiekenhuis(int persoonID, int ziekenhuisID)
        {
            string query = $"INSERT INTO peopleinhospital(Person, Hospital) VALUE('{persoonID}', '{ziekenhuisID}');";
            Insert(query);
        }

        public int InsertZiekenhuis(Ziekenhuis ziekenhuis, List<Persoon> personen)
        {
            int id = InsertZiekenhuis(ziekenhuis);
            foreach (Persoon p in personen)
            {
                voegMensenToeAanZiekenhuis(p.ID, id);
            }
            return id;
        }


        public List<Patiënt> SelecteerPatienten(int ziekenhuisID)
        {
            MySqlConnection verbinding = new MySqlConnection(verbindingString);
            string query = $"SELECT * FROM person " + //PAS OP VOOR SPATIES, MOETEN WORDEN BIJGEVOEGD!
                $"INNER JOIN peopleinhospital on person.ID = Person " +
                $"WHERE hospital = {ziekenhuisID} and Type = {_patient};";

            MySqlCommand commandDatabank = new MySqlCommand(query, verbinding);
            List<Patiënt> patienten = new List<Patiënt>();
            try
            {
                verbinding.Open();
                MySqlDataReader reader = commandDatabank.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string naam = (string)reader["Name"];
                    DateOnly geboortedatum = DateOnly.FromDateTime((DateTime)reader["Birth"]);
                    string reden = (string)reader["Problem"];
                    string oplossing = (string)reader["Treatment"];
                    patienten.Add(new Patiënt(id, geboortedatum, naam, reden, oplossing));
                }
                verbinding.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PROBLEEM A: {ex.Message}");
            }
            return patienten;

        }
        public List<Persoon> SelecteerPersoneel(int ziekenhuisID)
        {
            MySqlConnection verbinding = new MySqlConnection(verbindingString);
            string query = $"SELECT * FROM person " + //PAS OP VOOR SPATIES, MOETEN WORDEN BIJGEVOEGD!
                $"INNER JOIN peopleinhospital on person.ID = Person " +
                $"WHERE hospital = {ziekenhuisID} and Type != {_patient};";

            MySqlCommand commandDatabank = new MySqlCommand(query, verbinding);
            List<Persoon> personeel = new List<Persoon>();
            try
            {
                verbinding.Open();
                MySqlDataReader reader = commandDatabank.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader["Type"] == _dokter)
                    {
                        personeel.Add(new Dokter((int)reader["ID"], DateOnly.FromDateTime((DateTime)reader["Birth"]), (string)reader["Name"], (string)reader["Specialty"]));
                    }
                    else
                    {
                        Departement iets;
                        Enum.TryParse((string)reader["Area"], out iets);
                        personeel.Add(new Verpleegster((int)reader["ID"], DateOnly.FromDateTime((DateTime)reader["Birth"]), (string)reader["Name"], iets));
                    }
                }
                verbinding.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PROBLEEM B: {ex.Message}");
            }

            return personeel;

        }



    }
}
