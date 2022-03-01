using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Config;
using VRC.UI.Core.Styles;

namespace Versa.F_Ui
{
    class Unnecessary
    {
        internal static void TurnGameObject(bool _a) //мусор
        {
            try
            {
                InterfacePath.Carousel_Banners.SetActive(_a);
                InterfacePath.VRC_Banner.SetActive(_a);
            }
            catch { }
            try
            {
                GameObject.Destroy(InterfacePath.Image_Mask.GetComponent<StyleElement>());
            }
            catch { }
            try
            {
                InterfacePath.BackgroundLayer01.SetActive(_a);
            }
            catch { }
        }    }
}
