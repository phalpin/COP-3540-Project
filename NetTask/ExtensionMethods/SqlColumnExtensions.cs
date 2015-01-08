using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask.ExtensionMethods
{
    public static class SqlColumnExtensions
    {

        public static string MySQLAddToTable(this SqlColumn col, string tableName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("ALTER TABLE {0}\n", tableName);
            sb.AppendFormat(
                "ADD {0} {1}{2}{3}{4};",
                /*00*/col.Name,
                /*01*/col.DataType.MySQLDataType(),
                /*02*/col.Size != 0 ? "(" + col.Size.ToString() + ")" : string.Empty,
                /*03*/col.Nullable ? string.Empty : " NOT NULL",
                /*04*/col.AutoIncrement ? " AUTO_INCREMENT" : string.Empty
            );

            if (col.IsPrimaryKey)
            {
                sb.AppendLine();
                sb.AppendFormat("ALTER TABLE {0}\n", tableName);
                sb.AppendFormat(
                    "ADD CONSTRAINT pk_{0} PRIMARY KEY({0});",
                    /*00*/col.Name
                );
            }


            return sb.ToString();
        }

    }
}
