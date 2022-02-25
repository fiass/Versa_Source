using Versa.F_Config;
using System;
using UnityEngine;
using UnityEngine.UI;
using VRC;
namespace Versa.F_Module
{
    internal class Camera
    {
        internal static void FoVReset()
        {
            UnityEngine.Camera.main.fieldOfView = 60;
            FoVSave(UnityEngine.Camera.main.fieldOfView);
        }
        internal static void FoVPlus()
        {
            if (UnityEngine.Camera.main.fieldOfView < 110)
            {
                UnityEngine.Camera.main.fieldOfView = UnityEngine.Camera.main.fieldOfView + 10;
                FoVSave(UnityEngine.Camera.main.fieldOfView);
            }
        }
        internal static void FoVMinus()
        {
            if (UnityEngine.Camera.main.fieldOfView > 50)
            {
                UnityEngine.Camera.main.fieldOfView = UnityEngine.Camera.main.fieldOfView - 10;
                FoVSave(UnityEngine.Camera.main.fieldOfView);
            }
        }
        internal protected static void FoVSave(float value)
        {
            Data.FoV = value;
        }
        internal static void FoVLoad()
        {
            #region FoV
            if (Data.FoV > 40)
                UnityEngine.Camera.main.fieldOfView = Data.FoV;
            else
                FoVReset();
            #endregion

        }
        internal static void Enable()
        {
            Data.FoVScroll = true;
        }
        internal static void Disable()
        {
            Data.FoVScroll = false;
        }
        internal static void FoVScroll()
        {
          if(Data.FoVScroll)
            {
                float y = Input.mouseScrollDelta.y;
                if (y != 0)
                {
                    if (y >= 1)
                    {
                        UnityEngine.Camera.main.fieldOfView -= 5f;
                    }
                    else if (y >= -1)
                    {
                        UnityEngine.Camera.main.fieldOfView += 5f;
                    }
                }
            }
        }
        internal static void UnlockCameraLimits(bool unlock)
        {
            VRC.DataModel.NeckRange neckRange = new VRC.DataModel.NeckRange();
            if (unlock)
            {
                neckRange.field_Public_Single_0 = -360;
                neckRange.field_Public_Single_1 = 360;
            }
            else
            {
                neckRange.field_Public_Single_0 = -80;
                neckRange.field_Public_Single_1 = 70;
            }
        }
    }
}