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

namespace Versa.F_Module
{
    class VRCA
    {
        private static string str = string.Concat(Environment.CurrentDirectory + "/VRCA", '\\');

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
                client.Dispose();
                CustomConsole.Console("VRCA Downloaded");

            }catch(Exception e){ CustomConsole.Console(true, "VRCA.cs: " + e.Message); }
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
                client.Dispose();
                CustomConsole.Console("VRCA Downloaded");

            }
            catch (Exception e) { CustomConsole.Console(true, "VRCA.cs: " + e.Message); }
        }
    }
}
