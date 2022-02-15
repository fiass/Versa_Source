using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;
using Versa.F_Config;
using Versa.F_Core;

namespace Versa.F_Module
{
    class HotKeys
    {
        internal static void Control()
        {
            try
            {
                if (PlayerApi.MyPlayer() != null)
                {
                    if (Input.GetKey(KeyCode.Tab))
                    {
                        if (!Data.Is)
                            System.Windows.Forms.Application.Exit();

                        if (Input.GetKeyDown(KeyCode.F))
                            NoClip.Switch();
                        if (Input.GetKeyDown(KeyCode.E))
                            PlayerEsp.Switch();
                        //  if (Input.GetKeyDown(KeyCode.X))
                        //      PostProcessing.Switch();
                        //  if (Input.GetKeyDown(KeyCode.H))
                        //      ForceHide.HideToggle();
                        if (Input.GetKeyDown(KeyCode.W))
                            SpeedHack.Switch();
                        //  if (Input.GetKeyDown(KeyCode.O))
                        //      Optimization.Start();
                        //  if (Input.GetKeyDown(KeyCode.P))
                        //      Optimization.Start1();
                        //  if (Input.GetKeyDown(KeyCode.R))
                        //      CameraMod.FOVReset();
                    }
                }
            }
            catch { }
        }
    }
}