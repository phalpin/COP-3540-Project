using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask.ExtensionMethods
{
    public static class SQLDataTypeExtensions
    {

        public static string MySQLDataType(this SqlDataType type)
        {
            switch (type)
            {
                case SqlDataType.Integer:
                    return "INTEGER";
                case SqlDataType.NullableString:
                    return "VARCHAR";
                case SqlDataType.String:
                    return "VARCHAR";
            }

            return null;
        }

    }
}
