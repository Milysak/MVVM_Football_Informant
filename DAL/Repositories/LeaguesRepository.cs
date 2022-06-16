using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVM_Football_Informant.DAL.Repositories
{
    using Entities;
    static class LeaguesRepository
    {
        #region Queries
        private const string SELECT_ALL_LEAGUES = "SELECT * FROM leagues ORDER BY country";
        private const string SELECT_LEAGUES_FROM_FEDERATION = "SELECT * FROM leagues WHERE federationName = ";
        #endregion

        #region Methods
        public static List<League> DownloadAllLeagues()
        {
            var leagues = new List<League>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL_LEAGUES, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    leagues.Add(new League(reader));

                connection.Close();
            }

            return leagues;
        }

        public static List<League> DownloadNecessaryLeagues(string FederationName)
        {
            var leagues = new List<League>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{SELECT_LEAGUES_FROM_FEDERATION} {FederationName}", connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    leagues.Add(new League(reader));

                connection.Close();
            }

            return leagues;
        }
        #endregion
    }
}
