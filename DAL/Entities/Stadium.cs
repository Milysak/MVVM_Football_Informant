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
    DATA OTWARCIA
    ADRES
    POJEMNOŚĆ
    */

    class Stadium
    {
        public Stadium(MySqlDataReader reader)
        {
            this.Name = reader["name"].ToString();
            this.OpenYear = int.Parse(reader["openDate"].ToString());
            this.Address = reader["address"].ToString();
            this.Capacity = int.Parse(reader["capacity"].ToString());
        }

        public Stadium(string name, int openDate, string address, int capacity)
        {
            this.Name = name;
            this.OpenYear = openDate;
            this.Address = address;
            this.Capacity = capacity;
        }

        public string Name { get; private set; }

        public int OpenYear { get; private set; }

        public string Address { get; private set; }

        public int Capacity { get; private set; }

        public override string ToString()
        {
            return $"{Name} [{Capacity}]";
        }
    }
}
