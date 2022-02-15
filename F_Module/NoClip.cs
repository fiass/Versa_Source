using Versa.F_Config;
using Versa.F_Core;
using Versa.F_Output;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Versa.F_Module
{
    internal class NoClip
    {
        internal static void Switch()
        {
            switch (Data.NoClipEnabled)
            {
                case true:
                    State(false);
                    break;
                case false:
                    State(true);
                    break;
            }
        }
        internal static void State(bool _a)
        {
            Data.NoClipEnabled = _a;
            if (_a)
            {
                MelonCoroutines.Start(Enable());
            }
            else
            {
                Disable();
            }
        }
        internal static void Disable()
        {
            PlayerApi.playerNet().gameObject.GetComponent<CharacterController>().enabled = true;
        }
        internal static IEnumerator Enable()
        {
            Transform CamTransform;
            while (Data.NoClipEnabled)
            {
                if (PlayerApi.playerNet() != null)
                {
                    if (PlayerApi.playerNet().gameObject.GetComponent<CharacterController>().enabled)
                        PlayerApi.playerNet().gameObject.GetComponent<CharacterController>().enabled = false;
                    CamTransform = UnityEngine.Camera.current.transform;

                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        PlayerApi.playerNet().gameObject.transform.position -= CamTransform.transform.up * PlayerApi.playerNet().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 / 20f;
                    }
                    if (Input.GetKey(KeyCode.Space))
                    {
                        PlayerApi.playerNet().gameObject.transform.position += CamTransform.transform.up * PlayerApi.playerNet().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 / 20f;
                    }

                    if (PlayerApi.InputVertical() != 0f)
                    {
                        PlayerApi.playerNet().gameObject.transform.position +=
                             CamTransform.transform.forward *
                             PlayerApi.playerNet().gameObject.GetComponent<GamelikeInputController>()
                                 .field_Public_Single_0 * PlayerApi.InputVertical() / 20f;
                    }
                    if (PlayerApi.InputHorizontal() != 0f)
                    {
                        PlayerApi.playerNet().gameObject.transform.position +=
                            CamTransform.transform.right *
                            PlayerApi.playerNet().gameObject.GetComponent<GamelikeInputController>()
                                .field_Public_Single_0 * PlayerApi.InputHorizontal() / 20f;
                    }
                    if (PlayerApi.InputOculusVertical() != 0f)
                    {
                        PlayerApi.playerNet().gameObject.transform.position +=
                             CamTransform.transform.up *
                             PlayerApi.playerNet().gameObject.GetComponent<GamelikeInputController>()
                                 .field_Public_Single_0 * PlayerApi.InputOculusVertical() / 20f;
                    }
                }
                yield return new WaitForSeconds(0.00054f);
            }
        }
    }
}
