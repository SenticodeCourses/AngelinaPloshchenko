using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaPl.ConsoleApp.General
{
    partial class Program
    {
        static Dictionary<CommandStruct, Action> Command = new Dictionary<CommandStruct, Action>()
        {
            {new CommandStruct(){com2 = "+"}, new Action(MathOperation)},
            {new CommandStruct(){com2 = "-"}, new Action(MathOperation)},
            {new CommandStruct(){com2 = "/"}, new Action(MathOperation)},
            {new CommandStruct(){com2 = "*"}, new Action(MathOperation)},
            {new CommandStruct(){com1 = "date"}, new Action(DateNow)},
            {new CommandStruct(){com1 = "date", com2 = "hour"}, new Action(DateHour)},
            {new CommandStruct(){com1 = "date", com2 = "second"}, new Action(DateSecond)},
            {new CommandStruct(){com1 = "cons", com2 = "background", com3 = "color"}, new Action(ChangeBackGround)},
            {new CommandStruct(){com1 = "cons", com2 = "background", com3 = "color", com4 = "-black"}, new Action(ChangeBackGround)},
            {new CommandStruct(){com1 = "cons", com2 = "background", com3 = "color", com4 = "-yellow"}, new Action(ChangeBackGround)}
        };

        public static void MathOperation()
        {
            Type type = inputStrArr[0].GetType();

            if (inputStrArr.Length == 3)
            {
                double a, b;
                if (double.TryParse(inputStrArr[0], out var val1))
                {
                    a = val1;
                    if (double.TryParse(inputStrArr[2], out var val2))
                    {
                        b = val2;

                        if (inputStrArr[1] == "+") Console.WriteLine($"{a} + {b} = {a + b}");
                        if (inputStrArr[1] == "-") Console.WriteLine($"{a} - {b} = {a - b}");
                        if (inputStrArr[1] == "*") Console.WriteLine($"{a} * {b} = {a * b}");
                        if (inputStrArr[1] == "/" && b != 0.0) Console.WriteLine($"{a} / {b} = {a / b}");
                    }
                    else
                    {
                        if (inputStrArr[1] == "+")
                        {
                            Console.WriteLine($"{inputStrArr[0]} + {inputStrArr[2]} = {inputStrArr[0] + inputStrArr[2]}");
                        }
                    }
                }
                else
                {
                    if (inputStrArr[1] == "+")
                    {
                        Console.WriteLine($"{inputStrArr[0]} + {inputStrArr[2]} = {inputStrArr[0] + inputStrArr[2]}");
                    }
                }
            }
        }

        public static void DateNow()
        {
            Console.WriteLine(DateTime.Now);
        }

        public static void DateHour()
        {
            Console.WriteLine(DateTime.Now.Hour);
        }

        public static void DateSecond()
        {
            Console.WriteLine(DateTime.Now.Second);
        }

        public static void ChangeBackGround()
        {
            if (inputStrArr.Length == 4)
            {
                if (inputStrArr[3] == "-black") Console.BackgroundColor = ConsoleColor.Black;
                if (inputStrArr[3] == "-yellow") Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                int rand = rnd.Next(5);
                if (rand == 0) Console.BackgroundColor = ConsoleColor.Cyan;
                if (rand == 1) Console.BackgroundColor = ConsoleColor.Black;
                if (rand == 2) Console.BackgroundColor = ConsoleColor.DarkRed;
                if (rand == 3) Console.BackgroundColor = ConsoleColor.Magenta;
                if (rand == 4) Console.BackgroundColor = ConsoleColor.Yellow;
            }
        }
    }
}
