using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVM_Football_Informant.DAL.Repositories
{
    using Entities;
    static class WorkersRepository
    {
        #region Queries
        private const string SELECT_ALL_WORKERS = "SELECT * FROM workers";
        #endregion

        #region Methods
        public static List<Worker> DownloadAllWorkers()
        {
            var workers = new List<Worker>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL_WORKERS, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    workers.Add(new Worker(reader));

                connection.Close();
            }

            return workers;
        }
        #endregion
    }
}
