using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Output;
using VRC.SDKBase;
using Object = UnityEngine.Object;

namespace Versa.F_Module
{
    class Optimization
    {
        public static List<GameObject> _lst = new List<GameObject>();

        internal static async void State(bool state)
        {
            switch (state)
            {
                case true:
                    try
                    {
                        CustomConsole.Console(true, "Optimization.cs [started]");
                        _lst.Clear();
                        foreach (Light light in Object.FindObjectsOfType<Light>())
                        {
                            if (light.type != LightType.Directional)
                            {
                                _lst.Add(light.gameObject);
                            }
                        }
                        foreach (ParticleSystem particle in Object.FindObjectsOfType<ParticleSystem>())
                        {
                            if (!(particle.gameObject.name == "Trail") && !(particle.gameObject.name == "Ball") && !(particle.gameObject.name == "Glow"))
                            {
                                _lst.Add(particle.gameObject);
                            }
                        }
                        foreach (TrailRenderer trail in Object.FindObjectsOfType<TrailRenderer>())
                        {
                            _lst.Add(trail.gameObject);
                        }
                        foreach (VRCSDK2.VRC_ObjectSync pickup in Object.FindObjectsOfType<VRCSDK2.VRC_ObjectSync>())
                        {
                            _lst.Add(pickup.gameObject);
                        }
                        foreach (var x in _lst)
                        {
                            x.SetActive(false);
                        }
                        CustomConsole.Console(true, "Optimization.cs: [Items hidden: " + _lst.Count + "]");
                    }
                    catch (Exception e) { CustomConsole.Console(true, "Optimization.cs: " + e.Message); }
                    break;

                case false:
                    try
                    {
                        foreach (var x in _lst)
                        {
                            try
                            {
                                x.SetActive(true);
                            }
                            catch { }
                        }
                    }
                    catch { }
                    break;
            }
        }
    }
}
