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
            cmd.CommandText = string.Format("DROP DATABASE IF EXISTS {0};\nCREATE DATABASE {0};", databaseName);
            ExecuteNonQuery(conn, cmd);

        }


        public static void AddColumnsToTable(this MySqlConnection conn, string databaseName, string tableName, params SqlColumn[] columns) 
        {
            var cmd = conn.CreateCommand();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("USE {0};", databaseName);
            sb.AppendLine();
            foreach (var col in columns)
            {
                sb.AppendLine(col.MySQLAddToTable(tableName));
            }

            cmd.CommandText = sb.ToString();
            ExecuteNonQuery(conn, cmd);
        }

        private static void ExecuteNonQuery(MySqlConnection conn, MySqlCommand cmd)
        {
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
