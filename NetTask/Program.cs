using NetLog.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger.Options.UseColor = true;
            ConsoleLogger.Initialize();
            CLIManager.Run(args);
        }
    }
}
