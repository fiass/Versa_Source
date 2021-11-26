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
        internal static void Console(string text)
        {
            System.Console.WriteLine("[VERSA] " + text);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
        internal static void Console(bool isdebugmode, string text)
        {
            System.Console.ForegroundColor = GetRandomConsoleColor();
            if (isdebugmode && Data.Debug)
                System.Console.WriteLine("[DEBUG_MODE] " + text);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void Console(string text, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            Console(text);
        }
        internal static void Console(string _a, ConsoleColor _b, string _c)
        {
            System.Console.ForegroundColor = _b;
            Console(_c + _a);
        }
        internal static void Console(string _a, string _b)
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
