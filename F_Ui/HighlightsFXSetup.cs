using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Ui
{
    class HighlightsFXSetup
    {
        internal static void Setup()
        {
            HighlightsFX.prop_HighlightsFX_0.GetComponent<HighlightsFXStandalone>().blurIterations = 0;
        }
    }
}
