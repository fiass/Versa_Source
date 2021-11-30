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
using Versa.F_Ui;
using VRC.UI.Core.Styles;

namespace Versa.F_Module
{
    class CameraPreview
    {
        private static GameObject CacheObject;
        internal static void State(bool state) { }
        private static void CreateCamera()
        {
            try
            {
                GameObject temp = null;
                CustomConsole.Console(true, "Creating camera");
                temp = GameObject.Instantiate(Data.GameObjects[0], GameApi.SelectedPlayer().prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.Head));
                temp.GetComponent<UnityEngine.Camera>().transform.localPosition = new Vector3(0, 0, 0);
                CustomConsole.Console(true, "Caching camera");
                CacheObject = temp;
            }
            catch(Exception e) { CustomConsole.Console(true, "CameraPreview.cs [CreateCamera] " + e.Message); }
        }
        internal static async void CreateRender()
        {
            if(Data.PoVPreview)
            try
            {
                CustomConsole.Console(true, "CameraPreview.cs await 2s");
                await Task.Delay(1000);
                CreateCamera();
                CustomConsole.Console(true, "CameraPreview.cs await 1s");
                await Task.Delay(1000);
                CustomConsole.Console(true, "CameraPreview.cs await 0s");
                if (CacheObject != null)
                {
                    CacheObject.GetComponent<UnityEngine.Camera>().targetTexture = Data.renderTexture;
                    UiPath.PlayerIcon.GetComponent<MonoBehaviour1PublicGaLaVo12VoAwOnVo12VoUnique>().field_Public_RawImage_0.texture = new Texture();
                    UiPath.PlayerIcon.GetComponent<MonoBehaviour1PublicGaLaVo12VoAwOnVo12VoUnique>().field_Public_RawImage_0.material = new Material(UiPath.PlayerIcon.GetComponent<RawImage>().material)
                    {
                        mainTexture = Data.renderTexture
                    };
                    CustomConsole.Console(true, "Setup material");
                }
                else { CustomConsole.Console(true, "Player not founded, process stopped");  }
            }
            catch(Exception e) { CustomConsole.Console(true, "CameraPreview.cs [CreateRender] " + e.Message);; DestroyRender(); }
        }
        internal static void DestroyRender()
        {
            try
            {
                if (CacheObject != null)
                {
                    CustomConsole.Console(true, "Destroy camera");
                    GameObject.Destroy(CacheObject);
                }
            }
            catch(Exception e) { CustomConsole.Console(true, "CameraPreview.cs [DestroyRender] " + e.Message);}
        }
    }
}
