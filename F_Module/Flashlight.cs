using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Module
{
    class Flashlight
    {
        internal static GameObject gameObject;
        internal static async void Enable()
        {
            try
            {
                gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                gameObject.AddComponent<Light>().range = 50;
                gameObject.transform.SetParent(PlayerApi.MyVRCPlayer().transform);
            }
            catch (Exception e) { CustomConsole.Console(true, "Flashlight.cs [Enable] " + e.Message); }
        }
        internal static async void Disable()
        {
            try
            {
                GameObject.Destroy(gameObject);
            }
            catch (Exception e) { CustomConsole.Console(true, "Flashlight.cs [Disable] " + e.Message); }
        }
    }
}
