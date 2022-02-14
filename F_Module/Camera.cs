using Versa.F_Config;
using System;
using UnityEngine;
using UnityEngine.UI;
using VRC;
namespace Versa.F_Module
{
    internal class Camera
    {
        internal static bool _FoVScroll;
        internal static async void FoVReset()
        {
            UnityEngine.Camera.main.fieldOfView = 60;
            FoVSave(UnityEngine.Camera.main.fieldOfView);
        }
        internal static async void FoVPlus()
        {
            if (UnityEngine.Camera.main.fieldOfView < 110)
            {
                UnityEngine.Camera.main.fieldOfView = UnityEngine.Camera.main.fieldOfView + 10;
                FoVSave(UnityEngine.Camera.main.fieldOfView);
            }
        }
        internal static async void FoVMinus()
        {
            if (UnityEngine.Camera.main.fieldOfView > 50)
            {
                UnityEngine.Camera.main.fieldOfView = UnityEngine.Camera.main.fieldOfView - 10;
                FoVSave(UnityEngine.Camera.main.fieldOfView);
            }
        }
        internal protected static async void FoVSave(float value)
        {
            Data.FoV = value;
        }
        internal static async void FoVLoad()
        {
            #region FoV
            if (Data.FoV > 40)
                UnityEngine.Camera.main.fieldOfView = Data.FoV;
            else
                FoVReset();
            #endregion

            #region Scroll
            _FoVScroll = Data.FoVScroll;
            #endregion
        }
        internal static async void FoVUpdate()
        {

        }
        internal static async void FoVScroll()
        {
          if(_FoVScroll)
            {

            }
        }
        internal static async void UnlockCameraLimits(bool unlock)
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