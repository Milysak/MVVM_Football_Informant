using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVM_Football_Informant.DAL.Repositories
{
    using Entities;
    static class FederationsRepository
    {
        #region Queries
        private const string SELECT_ALL_FEDERATIONS = "SELECT * FROM federations";
        #endregion

        #region Methods
        public static List<Federation> DownloadAllFederations()
        {
            var federations = new List<Federation>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL_FEDERATIONS, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    federations.Add(new Federation(reader));

                connection.Close();
            }

            return federations;
        }
        #endregion
    }
}
