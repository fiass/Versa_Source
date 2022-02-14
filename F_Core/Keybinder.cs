using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Versa.F_Output;

namespace Versa.F_Core
{
    internal class KeybindWatcher
    {
        //Watch for keybinds in another thread which shouldn't crash the game I think
        internal static async void WatchKeybinds()
        {
            Task.Run((() =>
            {
                while (true)
                {
                    Thread.Sleep(1);
                }
            }));
        }
    }
}