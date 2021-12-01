using System;
using System.IO;

namespace Server.Core
{
    public class Logger
    {
        public static void Log(object Type, ConsoleColor Color = ConsoleColor.White)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.ResetColor();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            Console.ResetColor();
            Console.Write("] ");
            Console.ForegroundColor = Color;
            Console.Write(Type + "\n");
            Console.ResetColor();
        }
        
        public static void Log(object Type, object Message, ConsoleColor Color = ConsoleColor.White)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.ResetColor();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            Console.ResetColor();
            Console.Write("] [");
            Console.ForegroundColor = Color;
            Console.Write(Type + $"] {Message}\n");
            Console.ResetColor();
        }
    }
}