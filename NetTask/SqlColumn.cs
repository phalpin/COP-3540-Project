using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask
{
    public class SqlColumn
    {
        public SqlColumn() { }

        public string Name { get; set; }
        public int Size { get; set; }
        
        public bool AutoIncrement { get; set; }
        public bool Nullable { get; set; }

        private SqlDataType _dataType;
        public SqlDataType DataType
        {
            get { return _dataType; }
            set
            {
                if (value == SqlDataType.NullableString) Nullable = true;
                _dataType = value;
            }
        }

        private bool _isPrimaryKey;
        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set
            {
                if (value) Nullable = false;
                _isPrimaryKey = value;
            }
        }


    }

    public enum SqlDataType
    {
        String = 0,
        NullableString,
        Integer
    }
}
