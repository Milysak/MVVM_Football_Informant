using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVM_Football_Informant.DAL
{
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = 
            new MySqlConnectionStringBuilder();
        
        private static DBConnection instance = null;
        public static DBConnection Instance { 
            get
            { 
                if (instance == null) 
                    instance = new DBConnection(); 
                return instance; 
            } 
        }

        private MySqlConnection connection;
        public MySqlConnection Connection => connection;
            
        
        private DBConnection() {

            // stworzenie connection stringa na podstawie danych zapisanych w Settings do których mamy dostęp spoza aplikacji 
            stringBuilder.UserID = MVVM_Football_Informant.Properties.Settings.Default.userID;
            stringBuilder.Server = MVVM_Football_Informant.Properties.Settings.Default.server;
            stringBuilder.Database = MVVM_Football_Informant.Properties.Settings.Default.database;
            stringBuilder.Port = MVVM_Football_Informant.Properties.Settings.Default.port;
            stringBuilder.Password = MVVM_Football_Informant.Properties.Settings.Default.passwd;

            connection = new MySqlConnection(stringBuilder.ToString());
        }
    }
}
