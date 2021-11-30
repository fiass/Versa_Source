using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;
using Versa.F_Output;
using VRC;
using VRC.Core;

namespace Versa.F_Module
{
    class VRCA
    {
        private static readonly string str = string.Concat(Environment.CurrentDirectory + "/VRCA", '\\');
        private static readonly string str1 = string.Concat(Environment.CurrentDirectory + "/VRCW", '\\');
        internal async static void DownloadWorld()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "VRCW")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "VRCW"));
            try
            {
                ApiWorld world = GameApi.currentRoom.world;
                var client = new WebClient();
                string Your_Link = world.assetUrl;
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.2; .NET CLR 1.0.3705;)");
                CustomConsole.Console(true, "client.Ready");
                client.DownloadFileAsync(new Uri(Your_Link), str1 + $"[WORLD]{world.name} By {world.authorName}.vrcw");

                while (client.IsBusy)
                {
                    CustomConsole.Console(true, $"client.IsBusy = [{Your_Link}]");
                    await Task.Delay(1000);
                }
                CustomConsole.Console("VRCW  Downloaded");

            }catch (Exception e) { CustomConsole.Console(true, "VRCA.cs [DownloadWorld] " + e.Message); }
        }
        internal async static void DownloadSelect()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "VRCA")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "VRCA"));
            try
            {
                Player player = GameApi.SelectedPlayer();
                var client = new WebClient();
                string Your_Link = player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_ApiAvatar_0.assetUrl;
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.2; .NET CLR 1.0.3705;)");
                CustomConsole.Console(true, "client.Ready");
                client.DownloadFileAsync(new Uri(Your_Link), str + $"[SELECTED]{player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_ApiAvatar_0.name} By {player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_ApiAvatar_0.authorName}.vrca");

                while (client.IsBusy)
                {
                    CustomConsole.Console(true, $"client.IsBusy = [{Your_Link}]");
                    await Task.Delay(1000);
                }
                CustomConsole.Console("VRCA Downloaded");

            }catch(Exception e){ CustomConsole.Console(true, "VRCA.cs [DownloadSelect] " + e.Message); }
        }
        internal async static void DownloadMe()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "VRCA")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "VRCA"));
            try
            {
                Player player = PlayerApi.MyPlayer();
                var client = new WebClient();
                string Your_Link = player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_ApiAvatar_0.assetUrl;
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.2; .NET CLR 1.0.3705;)");
                CustomConsole.Console(true, "client.Ready");
                client.DownloadFileAsync(new Uri(Your_Link), str + $"[ME]{player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_ApiAvatar_0.name} By {player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_ApiAvatar_0.authorName}.vrca");

                while (client.IsBusy)
                {
                    CustomConsole.Console(true, $"client.IsBusy = [{Your_Link}]");
                    await Task.Delay(1000);
                }
                CustomConsole.Console("VRCA Downloaded");

            }
            catch (Exception e) { CustomConsole.Console(true, "VRCA.cs [DownloadMe] " + e.Message); }
        }
    }
}
