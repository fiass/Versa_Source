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

        internal static void State(bool state)
        {
            switch (state)
            {
                case true:
                    try
                    {
                        _lst.Clear();
                        foreach (Light light in Object.FindObjectsOfType<Light>())
                        {
                            if (light.type != LightType.Directional)
                            {
                                _lst.Add(light.gameObject);
                                light.gameObject.SetActive(false);
                            }
                        }
                        foreach (ParticleSystem particle in Object.FindObjectsOfType<ParticleSystem>())
                        {
                            if (!(particle.gameObject.name == "Trail") && !(particle.gameObject.name == "Ball") && !(particle.gameObject.name == "Glow"))
                            {
                                _lst.Add(particle.gameObject);
                                particle.gameObject.SetActive(false);
                            }
                        }
                        foreach (TrailRenderer trail in Object.FindObjectsOfType<TrailRenderer>())
                        {
                            _lst.Add(trail.gameObject);
                            trail.gameObject.SetActive(false);
                        }
                        foreach (VRC_Pickup pickup in Object.FindObjectsOfType<VRC_Pickup>())
                        {
                            _lst.Add(pickup.gameObject);
                            pickup.gameObject.SetActive(false);
                        }
                    }
                    catch(Exception e) { CustomConsole.Console(true, "Optimization.cs: " + e.Message); }
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
