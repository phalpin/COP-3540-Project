using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask.ExtensionMethods
{
    public static class MySqlConnectionExtensions
    {
        public static void CreateDatabase(this MySqlConnection conn, string databaseName)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("CREATE DATABASE {0}", databaseName);
            var ret = cmd.ExecuteNonQuery();
        }
    }
}
