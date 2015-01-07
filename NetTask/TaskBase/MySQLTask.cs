using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NetTask.Attributes;

namespace NetTask.TaskBase
{
    [ExcludeTask]
    public abstract class MySQLTask : BaseTask
    {

        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }
        private string ConnectionString
        {
            get
            {
                var connStringBuilder = new MySqlConnectionStringBuilder
                {
                    UserID = Username,
                    Server = Address,
                    Password = Password,
                    ConnectionTimeout = (uint)Timeout
                };

                return connStringBuilder.ConnectionString;
            }
        }
        private MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(ConnectionString);
            }
        }

        public MySQLTask()
        {
            Address = WebCart.Core.Consts.DB_ADDRESS;
            Username = WebCart.Core.Consts.DB_USERNAME;
            Password = WebCart.Core.Consts.DB_PASSWORD;
            Timeout = WebCart.Core.Consts.DB_TIMEOUT;
        }

        public override sealed void Execute()
        {
            base.Execute();
            using (var db = Connection)
            {
                ExecuteSql(db);
            }
            
        }

        protected abstract void ExecuteSql(MySqlConnection conn);

    }
}
