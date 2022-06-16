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
    KONTYNENT
    PREZES
    */

    class Federation
    {
        public Federation(MySqlDataReader reader)
        {
            this.Name = reader["name"].ToString();
            this.Continent = reader["continent"].ToString();
            this.Chef = reader["chef"].ToString();
        }

        public Federation(string name, string continent, string chef)
        {
            this.Name = name;
            this.Continent = continent;
            this.Chef = chef;
        }

        public string Name { get; private set; }

        public string Continent { get; private set; }

        public string Chef { get; private set; }

        public override string ToString()
        {
            return $"{Name} [{Continent}]";
        }
    }
}
