using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linapl.SystemMonitoring.FolderMonitoring;
using System.Threading;

namespace Linapl.SystemMonitoring.App
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderMonitor dev1 = new FolderMonitor(@"E:\dev1");
            dev1.IsMonitoring = true;
            //dev1.Monitoring();
            Thread thread = new Thread(dev1.Monitoring);
            thread.Start();
            thread.Priority = ThreadPriority.Highest;

            for (;;)
            {
                string str = Console.ReadLine();
                dev1.IsMonitoring = !dev1.IsMonitoring;
                Console.WriteLine("!!!");
            }

            Console.ReadLine();
        }
    }
}
