using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVM_Football_Informant.DAL.Entities
{
    /*
    NAZWA - Klucz Główny
    MIASTO
    ROK ZAŁOŻENIA
    PRZYDOMEK
    WARTOŚĆ KADRY
    ILOŚĆ TROFEÓW
    */

    class Club
    {
        // Ten konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Club(MySqlDataReader reader)
        {
            this.Name = reader["name"].ToString();
            this.City = reader["city"].ToString();
            this.YearOfForm = int.Parse(reader["formYear"].ToString());
            this.Alias = reader["alias"].ToString();
            this.ValueOfTeam = int.Parse(reader["teamValue"].ToString());
            this.NumberOfTrophies = int.Parse(reader["trophiesNumber"].ToString());
            this.LeagueName = reader["leagueName"].ToString();
            this.StadiumName = reader["stadiumName"].ToString();
        }

        public Club(string name, string city, int yearOfForm, string alias, long valueOfTeam, int numberOfTrophies, string leagueName, string stadiumName)
        {
            this.Name = name;
            this.City = city;
            this.YearOfForm = yearOfForm;
            this.Alias = alias;
            this.ValueOfTeam = valueOfTeam;
            this.NumberOfTrophies = numberOfTrophies;
            this.LeagueName = leagueName;
            this.StadiumName = stadiumName;
        }

        public string Name { get; private set; }

        public string City { get; private set; }

        public int YearOfForm { get; private set; }

        public string Alias { get; private set; }

        public long ValueOfTeam { get; private set; }

        public int NumberOfTrophies { get; private set; }

        public string LeagueName { get; private set; }

        public string StadiumName { get; private set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}