using NetTask.TaskBase;
using NetTask.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask.Tasks.Database
{
    public class createDatabase : MySQLTask
    {

        public string DatabaseName { get; set; }
        
        public createDatabase()
        {
            DatabaseName = WebCart.Core.Consts.DB_NAME;
        }

        protected override void ExecuteSql(MySql.Data.MySqlClient.MySqlConnection conn)
        {
            conn.CreateDatabase(DatabaseName);
        }
    }
}
