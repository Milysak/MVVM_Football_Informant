using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace MVVM_Football_Informant.DAL.Repositories
{
    using Entities;
    static class ClubsRepository
    {
        #region Queries
        private const string SELECT_ALL_CLUBS = "SELECT * FROM clubs ORDER BY name";
        private const string SELECT_CLUBS_FROM_LEAGUE = "SELECT * FROM clubs WHERE leagueName = ";

        // ranking
        private const string SELECT_CLUBS_SORTED_TROPHIES = "SELECT * FROM clubs ORDER BY trophiesNumber DESC";
        private const string SELECT_CLUBS_SORTED_VALUE = "SELECT * FROM clubs ORDER BY teamValue DESC";
        private const string SELECT_CLUBS_SORTED_FORMYEAR = "SELECT * FROM clubs ORDER BY formYear";
        #endregion

        #region Methods
        public static List<Club> DownloadAllClubs()
        {
            var clubs = new List<Club>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL_CLUBS, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    clubs.Add(new Club(reader));

                connection.Close();
            }

            return clubs;
        }

        public static List<Club> DownloadSortedClubsBy(string rankingType)
        {
            var clubs = new List<Club>();
            MessageBox.Show("");

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command;

                if (rankingType.Equals("Trofea"))
                {
                    command = new MySqlCommand(SELECT_CLUBS_SORTED_TROPHIES, connection);
                }
                else if(rankingType.Equals("Wartość"))
                {
                    command = new MySqlCommand(SELECT_CLUBS_SORTED_VALUE, connection);
                }
                else if(rankingType.Equals("Najstarszy"))
                {
                    command = new MySqlCommand(SELECT_CLUBS_SORTED_FORMYEAR, connection);
                }
                else
                {
                    return null;
                }

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    clubs.Add(new Club(reader));

                connection.Close();
            }

            return clubs;
        }
        #endregion
    }
}
