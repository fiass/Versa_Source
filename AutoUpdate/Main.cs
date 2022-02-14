using Ionic.Zip;
using MelonLoader;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate
{
    public static class BuildInfo
    {
        public const string Name = "Versa Update"; // Name of the Plugin.  (MUST BE SET)
        public const string Description = "Plugin for Versa Updating"; // Description for the Plugin.  (Set as null if none)
        public const string Author = "Null"; // Author of the Plugin.  (MUST BE SET)
        public const string Company = null; // Company that made the Plugin.  (Set as null if none)
        public const string Version = "1.1.2"; // Version of the Plugin.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Plugin.  (Set as null if none)
    }

    public class AutoUpdate : MelonPlugin
    {
        public override void OnPreInitialization() // Runs before Game Initialization.
        {
            Download();

        }
        internal static string Path = Directory.GetCurrentDirectory();
        internal static async void Download()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-1.bin", $@"{Path}\CharCrypt.dll");
                    while (client.IsBusy)
                    {
                        await Task.Delay(100);
                    }
                    client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-2.bin", $@"{Path}\DotNetZip.dll");
                    while (client.IsBusy)
                    {
                        await Task.Delay(100);
                    }
                    client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-3.bin", $@"{Path}\LiteDatabase.dll");
                    while (client.IsBusy)
                    {
                        await Task.Delay(100);
                    }
                    client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-4.bin", $@"{Path}\Plugins\AutoUpdate.dll");
                    while (client.IsBusy)
                    {
                        await Task.Delay(100);
                    }
                    client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-5.bin", $@"{Path}\Mods\Versa.dll");
                    while (client.IsBusy)
                    {
                        await Task.Delay(100);
                    }
                    if(File.Exists($@"{Path}\Plugins\AutoUpdateVersa.dll"))
                    {
                        File.Delete($@"{Path}\Plugins\AutoUpdateVersa.dll");
                    }
                }
            }
            catch { }
        }
        public static  char[] Char_1 =
        {
           (char)(89000f * 0.024f / +(+24)),
           (char)(111000f * 0.024f / +(+24)),
           (char)(117000f * 0.024f / +(+24)),
           (char)(76000f * 0.024f / +(+24)),
           (char)(111000f * 0.024f / +(+24)),
           (char)(115000f * 0.024f / +(+24)),
           (char)(101000f * 0.024f / +(+24)),
           (char)(76000f * 0.024f / +(+24)),
           (char)(105000f * 0.024f / +(+24)),
           (char)(99000f * 0.024f / +(+24)),
           (char)(101000f * 0.024f / +(+24)),
           (char)(110000f * 0.024f / +(+24)),
           (char)(115000f * 0.024f / +(+24)),
           (char)(101000f * 0.024f / +(+24)),
        };
        public override void OnApplicationEarlyStart() // Runs after Game Initialization, before OnApplicationStart and (on Il2Cpp games) before Unhollower.
        {
        }

        public override void OnApplicationStart() // Runs after Game Initialization.
        {
        }

        public override void OnApplicationLateStart() // Runs after OnApplicationStart.
        {
        }

        public override void OnUpdate() // Runs once per frame.
        {
        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {
        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
        }

        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
        }

        public override void OnPreferencesSaved() // Runs when Melon Preferences get saved.
        {
        }

        public override void OnPreferencesLoaded() // Runs when Melon Preferences get loaded.
        {
        }
    }
}