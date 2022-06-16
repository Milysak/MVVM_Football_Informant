using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVM_Football_Informant.DAL.Entities
{
    /*
    ID - Klucz Główny
    IMIĘ
    NAZWISKO
    FUNKCJA
    */

    class Worker
    {
        public Worker(MySqlDataReader reader)
        {
            this.Id = int.Parse(reader["id"].ToString());
            this.Name = reader["name"].ToString();
            this.Surname = reader["surname"].ToString();
            this.Function = reader["job"].ToString();
            this.ClubName = reader["clubName"].ToString();
        }

        public Worker(int id, string name, string surname, string function, string clubName)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Function = function;
            this.ClubName = clubName;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Function { get; private set; }

        public string ClubName { get; private set; }

        public override string ToString()
        {
            return $"{Name} {Surname} - {Function}";
        }
    }

}
