using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinaPl.ConsoleApp.General
{
    partial class Program
    {
        static string inputStr;
        static string[] inputStrArr;
        static void Main(string[] args)
        {
            for (;;)
            {
                inputStr = Console.ReadLine();
                inputStrArr = inputStr.Split(' ');
                Method();
            }
        }
    }
}
