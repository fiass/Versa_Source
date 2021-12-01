using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;
using Versa.F_Ui;
using Versa.F_Output;

namespace Versa.F_Module
{
    class PlayerEsp
    {
        #region CapsuleESP
        private static bool _b;
        internal static void Capsule(bool state)
        {
            switch (state)
            {
                case true:
                    _b = state;
                    MelonCoroutines.Start(ActivateCapsule());
                    break;
                case false:
                    _b = state;
                    break;
            }
        }
        private static IEnumerator ActivateCapsule()
        {
            while (_b)
            {
                try
                {
                        Highlights(_b);
                }
                catch (Exception e) { CustomConsole.Console(true, e.Message); }

                yield return new WaitForSeconds(1f);
            }
            Highlights(_b);
        }
        private static void Highlights(bool _a)
        {
            try
            {
                GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].transform.Find("SelectRegion"))
                    {
                        array[i].transform.Find("SelectRegion").GetComponent<Renderer>().sharedMaterial.SetColor("_Color", UiManager.StringToColor(Prefs.String.Load("CapsuleColor")));
                        if (_a)
                        {
                            HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(
                                                         array[i].transform.Find("SelectRegion").GetComponent<Renderer>(), true);
                        }
                        else
                        {
                            HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(
                                                          array[i].transform.Find("SelectRegion").GetComponent<Renderer>(), false);
                        }
                    }
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "PlayerEsp.cs [Highlights] " + e.Message); }
        }
        #endregion
            private static void Lines()
        {
            GameObject[] array = GameObject.FindGameObjectsWithTag("Player");

        }
    }
}
