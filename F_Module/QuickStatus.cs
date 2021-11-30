using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Config;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Module
{
    class QuickStatus
    {

        internal static void Icons()
        {
            foreach (UiStatusIcon a in Resources.FindObjectsOfTypeAll<UiStatusIcon>())
            {    
                a.gameObject.GetComponent<RawImage>().texture = Data.Textures[98];
            }
        }
        
    }
}
