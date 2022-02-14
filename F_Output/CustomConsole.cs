using Versa.F_Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versa.F_Output
{
   internal class CustomConsole
    {
        internal static async void Console(string text)
        {
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} ");
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.Write("_VERSA_");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write($" v{BuildInfo.Version}");
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.Write("]");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(text);
        }
        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(1,consoleColors.Length));
        }
        internal static async void Console(bool isdebugmode, string text)
        {
            LogWriter.WriteLog($"[{DateTime.Now}] - {text}");
            System.Console.ForegroundColor = GetRandomConsoleColor();
            if (isdebugmode & Data.Debug)
                System.Console.WriteLine($"[DEBUG_MODE][{DateTime.Now}] {text}");
            System.Console.ForegroundColor = ConsoleColor.White;
        }
        internal static async void Console(string text, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            Console(text);
        }
        internal static async void Console(string _a, ConsoleColor _b, string _c)
        {
            System.Console.ForegroundColor = _b;
            Console(_c + _a);
        }
        internal static async void Console(string _a, string _b)
        {
            Console(_b + _a);
        }
        #region Attention
        internal static string Info
        {
            get { return "[Info] "; }
        }
        internal static string Warning
        {
            get { return "[Warning] "; }
        }
        internal static string Error
        {
            get { return "[Error] "; }
        }
        #endregion
    }
}
