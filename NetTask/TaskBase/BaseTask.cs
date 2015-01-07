using NetLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetTask.TaskBase
{
    public abstract class BaseTask : IBaseTask
    {

        #region Reflection QOL Stuff
        public static Type Type
        {
            get
            {
                return MethodBase.GetCurrentMethod().DeclaringType;
            }
        }
        public static string TaskName
        {
            get
            {
                return Type.Name;
            }
        }
        public static IEnumerable<PropertyInfo> Properties
        {
            get
            {
                return Type.GetProperties();
            }
        }
        #endregion

        public virtual void Execute()
        {
            Log.Message("Executing {0}", TaskName);
        }

    }
}
