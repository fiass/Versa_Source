using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using UnhollowerBaseLib;
using UnityEngine;
using Versa.F_Config;
using Versa.F_Output;
using VRC;
using VRC.Core;

namespace Versa.F_Module
{
    class AntiCrash
    {
        internal static void State(bool state) => Data.Toggle.AntiCrash = state;
        public static int PolygonLimits = 500000;
        public static List<string> Whitelist;
        internal static void CheckPlayer(Player player)
        {
            try
            {
                //Lazy check
                if (player.prop_APIUser_0.id == APIUser.CurrentUser.id) return;
                
                
                
                bool Max = PolygonCheck(player, GetPolyCount(player.prop_VRCPlayer_0.field_Internal_GameObject_0));
                if (Max)
                    CustomConsole.Console("[Anti-Crsah] "+ player.prop_APIUser_0.displayName + $" Over {PolygonLimits / 100}k poly, Avatar destroy");
            }
            catch (Exception e) { CustomConsole.Console(true, "AntiCrash.cs [CheckPlayer] " + e.Message); }
        }
        private static int GetPolyCount(GameObject player)
        {
            int num = 0;
            try
            {
                foreach (SkinnedMeshRenderer skinnedMeshRenderer in player.GetComponentsInChildren<SkinnedMeshRenderer>(true))
                {
                    if (skinnedMeshRenderer != null && !(skinnedMeshRenderer.sharedMesh == null))
                    {
                        num += CountPolyMeshes(skinnedMeshRenderer.sharedMesh);
                    }
                }
                foreach (MeshFilter meshFilter in player.GetComponentsInChildren<MeshFilter>(true))
                {
                    if (meshFilter != null && !(meshFilter.sharedMesh == null))
                    {
                        num += CountPolyMeshes(meshFilter.sharedMesh);
                    }
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "AntiCrash.cs [GetPolyCount] " + e.Message); }
            return num;
        }

        internal static int CountPolys(Renderer r)
        {
            int num = 0;
            SkinnedMeshRenderer skinnedMeshRenderer = r as SkinnedMeshRenderer;
            if (skinnedMeshRenderer != null)
            {
                if (skinnedMeshRenderer.sharedMesh == null)
                {
                    return 0;
                }
                num += CountPolyMeshes(skinnedMeshRenderer.sharedMesh);
            }
            return num;
        }

        private static int CountPolyMeshes(Mesh sourceMesh)
        {
            bool flag = false;
            Mesh mesh;
            int num = 0;
            try
            {
                if (sourceMesh.isReadable)
                {
                    mesh = sourceMesh;
                }
                else
                {
                    mesh = UnityEngine.Object.Instantiate<Mesh>(sourceMesh);
                    flag = true;
                }
                for (int i = 0; i < mesh.subMeshCount; i++)
                {
                    num += mesh.GetTriangles(i).Length / 3;
                }
                if (flag)
                {
                    UnityEngine.Object.Destroy(mesh);
                }
            }
            catch(Exception e) { CustomConsole.Console(true, "AntiCrash.cs [CountPolyMeshes] " + e.Message); }
            return num;
        }

        internal static bool PolygonCheck(Player user, int polys)
        {
            try
            {
                if (polys >= PolygonLimits)
                {
                    try
                    {
                        foreach (var whiteuser in Whitelist)
                        {
                            if (whiteuser.Contains(user.prop_APIUser_0.id))
                                return false;
                        }
                    }
                    catch { CustomConsole.Console(true, $"User: {user.prop_APIUser_0.displayName} not in WhiteList" ); }
                    Il2CppArrayBase<Renderer> componentsInChildren = user.prop_VRCPlayer_0.prop_VRCAvatarManager_0.GetComponentsInChildren<Renderer>(true);
                    for (int i = 0; i < componentsInChildren.Count; i++)
                    {
                        Renderer renderer = componentsInChildren[i];
                        if (!(renderer == null) && renderer.enabled)
                        {
                            renderer.enabled = false;
                            UnityEngine.Object.Destroy(renderer);
                        }
                    }
                    return true;
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "AntiCrash.cs [PolygonCheck] " + e.Message); }
            return false;
        }

        internal static bool PhotonScan(int PhotonID, EventData eventData)
        {
            return true;
        }
    }
}
