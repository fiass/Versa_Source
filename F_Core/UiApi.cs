using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using VRC.UI.Core;
using VRC.UI.Elements;

namespace Versa.F_Core
{
    internal class UiApi
    {
        internal static UIManager prop_UIManager_0()
        {
            try
            {
                return UIManager.prop_UIManager_0;
            }
            catch
            {
                return null;
            }
        }
        internal static GameObject UiManager_GameObject()
        {
            try
            {
                return UIManager.prop_UIManager_0.gameObject;
            }
            catch
            {
                return null;
            }
        }
        public static PostProcessLayer postProcessLayer
        {
            get
            {
                return Resources.FindObjectsOfTypeAll<PostProcessLayer>()[2];
            }
        }

    }
}
