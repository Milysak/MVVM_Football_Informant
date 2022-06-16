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
    KRAJ 
    POZIOM ROZGRYWKOWY
    POZYCJA W RANKINGU
    */

    class League
    {
        public League(MySqlDataReader reader)
        {
            this.Name = reader["name"].ToString();
            this.Country = reader["country"].ToString();
            this.Level = short.Parse(reader["level"].ToString());
            this.PositionInRanking = reader["rankingPosition"].ToString();
            this.FederationName = reader["federationName"].ToString();
        }

        public League(string name, string country, short level, string positionInRanking, string federationName)
        {
            this.Name = name;
            this.Country = country;
            this.Level = level;
            this.PositionInRanking = positionInRanking;
            this.FederationName = federationName;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public short Level { get; private set; }

        public string PositionInRanking { get; private set; }

        public string FederationName { get; private set; }

        public override string ToString()
        {
            return $"{Name} [{Country}]";
        }
    }
}
