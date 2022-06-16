using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVM_Football_Informant.DAL.Repositories
{
    using Entities;
    static class StadiumsRepository
    {
        #region Queries
        private const string SELECT_ALL_STADIUMS = "SELECT * FROM stadiums";
        private const string SELECT_NECESSARY_STADIUM = "SELECT * FROM stadiums where name = ";
        #endregion

        #region Methods
        public static List<Stadium> DownloadAllStadiums()
        {
            var stadiums = new List<Stadium>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL_STADIUMS, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    stadiums.Add(new Stadium(reader));

                connection.Close();
            }

            return stadiums;
        }

        public static Stadium DownloadNecessaryStadium(string StadiumName)
        {
            Stadium stadium;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{SELECT_NECESSARY_STADIUM} {StadiumName}", connection);

                connection.Open();

                var reader = command.ExecuteReader();

                stadium = new Stadium(reader);

                connection.Close();
            }

            return stadium;
        }
        #endregion
    }
}
