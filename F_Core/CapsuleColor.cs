using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Output;
using Versa.F_Ui;

namespace Versa.F_Core
{
    class CapsuleColor
    {
        internal static void Capsule()
        {
            try
            {
                GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].transform.Find("SelectRegion"))
                    {
                        array[i].transform.Find("SelectRegion").GetComponent<Renderer>().sharedMaterial.SetColor("_Color", UiManager.StringToColor(Prefs.String.Load("CapsuleColor")));
                    }
                }
                F_Output.CustomConsole.Console(true, "[CapsuleColor has apply]");
            }
            catch (Exception e) { CustomConsole.Console(true, "CapsuleColor.cs: "+e.Message); }
        }
    }
}
