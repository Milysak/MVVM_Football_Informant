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

    class RankingsRepository
    {
        #region Queries
        private const string SELECT_TO_RANKING_1 = "SELECT * FROM ";
        private const string SELECT_TO_RANKING_2 = " ORDER BY ";
        private const string SELECT_TO_RANKING_3 = " WHERE ";
        #endregion

        #region Methods
        public static List<dynamic> DownloadToRanking(string targetType, string orderType, string whereType)
        {
            var list = new List<dynamic>();

            using (var connection = DBConnection.Instance.Connection)
            {
                var where = "";
                var SELECT_COMMAND = "";

                if (whereType != null)
                {
                    if (targetType.Equals("leagues"))
                    {
                        where = "federationName = ";
                    }
                    else if (targetType.Equals("clubs"))
                    {
                        where = "leagueName = ";
                    }
                    SELECT_COMMAND = SELECT_TO_RANKING_1 + targetType + SELECT_TO_RANKING_3 + where + "'" + whereType + "'" + " AND " + orderType + " IS NOT NULL " + SELECT_TO_RANKING_2 + orderType;
                }
                else
                {
                    SELECT_COMMAND = SELECT_TO_RANKING_1 + targetType + " WHERE " + orderType + " IS NOT NULL " + SELECT_TO_RANKING_2 + orderType;
                }
                
                if (targetType.Equals("stadiums"))
                {
                    SELECT_COMMAND = SELECT_TO_RANKING_1 + targetType + SELECT_TO_RANKING_2 + orderType;
                }

                if (orderType.Equals("teamValue") || orderType.Equals("trophiesNumber") || orderType.Equals("capacity"))
                {
                    SELECT_COMMAND += " DESC";
                }

                //MessageBox.Show(SELECT_COMMAND);

                MySqlCommand command = new MySqlCommand(SELECT_COMMAND, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(targetType.Equals("leagues"))
                    {
                        list.Add(new League(reader));
                    }
                    else if (targetType.Equals("clubs"))
                    {
                        list.Add(new Club(reader));
                    }
                    else if (targetType.Equals("stadiums"))
                    {
                        list.Add(new Stadium(reader));
                    }
                    else
                    {
                        connection.Close();
                        return list;
                    }
                }

                connection.Close();
            }

            return list;
        }
        #endregion
    }
}
