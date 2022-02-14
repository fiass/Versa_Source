using Versa.F_Config;
using Versa.F_Core;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Versa.F_Module
{
    class TabControl
    {
        internal static async void Tips()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                GUI.Box(new Rect(50, UnityEngine.Screen.height - 50, 300, 25),
                    DateTime.Now.ToString() + " | Fps:" + Math.Round(1.0f / Time.deltaTime, 0));
               }
        }
    }
}
