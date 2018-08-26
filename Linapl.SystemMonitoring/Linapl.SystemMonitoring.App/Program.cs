using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linapl.SystemMonitoring.FolderMonitoring;

namespace Linapl.SystemMonitoring.App
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderMonitor dev1 = new FolderMonitor(@"G:\dev1");
            dev1._isMonitoring = true;
            dev1.Monitoring();
            Console.ReadLine();
        }
    }
}
