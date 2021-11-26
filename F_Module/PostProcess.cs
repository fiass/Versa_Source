using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering.PostProcessing;
using Versa.F_Core;

namespace Versa.F_Module
{
    class PostProcess
    {
        internal static void State(bool state)
        {
            switch (state)
            {
                case true:
                    UiApi.postProcessLayer.enabled = true;
                    break;

                case false:
                    UiApi.postProcessLayer.enabled = false;
                    break;
            }
        }
    }
}
