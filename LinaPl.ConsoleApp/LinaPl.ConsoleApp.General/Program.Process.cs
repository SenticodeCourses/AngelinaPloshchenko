using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaPl.ConsoleApp.General
{
    partial class Program
    {
        public static void Method()
        {
            CommandStruct commandStr = new CommandStruct();
            switch (inputStrArr.Length)
            {
                case 1:
                    commandStr.com1 = inputStrArr[0];
                    break;
                case 2:
                    commandStr.com1 = inputStrArr[0];
                    commandStr.com2 = inputStrArr[1];
                    break;
                case 3:
                    commandStr.com1 = inputStrArr[0];
                    commandStr.com2 = inputStrArr[1];
                    commandStr.com3 = inputStrArr[2];
                    break;
                case 4:
                    commandStr.com1 = inputStrArr[0];
                    commandStr.com2 = inputStrArr[1];
                    commandStr.com3 = inputStrArr[2];
                    commandStr.com4 = inputStrArr[3];
                    break;
            }

            if (Command.TryGetValue(commandStr, out var method))
            {
                method();
            }
            else
            {
                commandStr.com1 = null;
                commandStr.com3 = null;
                if (Command.TryGetValue(commandStr, out var mathMethod))
                {
                    mathMethod();
                }
            }
        }
    }
}
