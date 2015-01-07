using NetLog;
using NetTask.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask
{
    public static class ReflectionUtils
    {
        public static T GetAttribute<T>(this Type t) where T : BaseTaskAttribute
        {
            var existingAttribute = t.GetCustomAttributes(typeof(T), false);

            T resultantAttribute = default(T);
            switch (existingAttribute.Length)
            {
                case 0:                    
                    break;
                case 1:
                    resultantAttribute = existingAttribute[0] as T;
                    break;
                default:
                    Log.Error("Found multiple attributes of type {0} on type {1}", typeof(T).Name, t.Name);
                    break;
            }

            return resultantAttribute;
        }

        public static bool ShouldInclude(this Type t)
        {
            return t.GetAttribute<ExcludeTaskAttribute>() == null;
        }
    }
}
