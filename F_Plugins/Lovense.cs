using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Output;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Versa.F_Plugins
{
    internal class Lovense
    {

        static extern IntPtr LoadLibrary(string lpFileName);

        internal static async void Startup()
        {
            if (File.Exists($@"{Directory.GetCurrentDirectory()}\Mods\Versa Plugins\LovenseMod.dll"))
            {

            }
        }
    }
}
