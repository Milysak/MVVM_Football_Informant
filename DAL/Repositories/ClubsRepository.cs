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
        #endregion

        #region Methods
        public static List<Club> DownloadAllClubs()
        {
            var clubs = new List<Club>();

            // korzystając z instrukcji using mamy pewność, że po zakończeniu operacji na pliku zasoby systemowe zostaną zwolnione
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
        #endregion
    }
}
