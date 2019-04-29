using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.DB
{
    class DataBase
    {
        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection("Data Source=database\\database.sqlite;Version=3;");
            connection.Open();
            return connection;
        }

    }
}
