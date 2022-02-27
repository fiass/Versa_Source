using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Config;

namespace Versa.F_Module
{
    class PolygonShow
    {
        public static Il2CppSystem.Collections.Generic.List<Material> materials = new Il2CppSystem.Collections.Generic.List<Material>();
        static Transform[] go;
        internal static async void Enable()
        {
            go = null;
            materials.Clear();
            go = UnityEngine.Object.FindObjectsOfType<Transform>();
            foreach (var obj in go)
            {
                try
                {
                    materials.Add(obj.gameObject.GetOrAddComponent<MeshRenderer>().material);
                    if(obj.name != "MenuMesh")
                    obj.gameObject.GetOrAddComponent<MeshRenderer>().material = Data.Materials[1];
                }
                catch { }
            }
        }
        internal static async void Disable()
        {
            for (int i = 0; i != materials.Count; i++)
            {
                try
                {
                    go[i].GetComponent<MeshRenderer>().material = materials[i];
                }
                catch { }
            }
            materials.Clear();
        }
    }
}
