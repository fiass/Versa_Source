using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering.PostProcessing;
using Versa.F_Config;
using Versa.F_Core;

namespace Versa.F_Module
{
    class PostProcess
    {
        internal static void Switch()
        {
            switch (Data.Toggle.PostProcess)
            {
                case true:
                    Data.Toggle.PostProcess = false;
                    State(false);
                    break;
                case false:
                    Data.Toggle.PostProcess = true;
                    State(true);
                    break;
            }
        }
        internal static void State(bool state) => UiApi.postProcessLayer.enabled = state;
    }
}
