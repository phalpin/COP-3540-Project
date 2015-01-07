using NetLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetTask
{
    public static class CLIManager
    {

        public static IEnumerable<Type> AvailableTasks
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetTypes().Where(d => d.IsSubclassOf(typeof(TaskBase.BaseTask)) && d.ShouldInclude());
            }
        }
        
        public static void Run(params string[] args)
        {
            var test = AvailableTasks;
        }

    }
}
