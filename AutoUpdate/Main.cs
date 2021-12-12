using Ionic.Zip;
using MelonLoader;
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
        public const string Version = "1.0.0"; // Version of the Plugin.  (MUST BE SET)
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
                    client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Setup", $@"{Path}\Versa-Setup.zip");
                    while (client.IsBusy)
                    {
                        await Task.Delay(100);
                    }
                }
            }
            catch { }
            try
            {
                using (ZipFile zip = ZipFile.Read($@"{Path}\Versa-Setup.zip", new ReadOptions { Encoding = Encoding.GetEncoding("cp866") }))
                {
                    foreach (ZipEntry eq in zip)
                    {
                        eq.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                        eq.ExtractWithPassword(Path, new string(CharCrypt.SetupVersa_Crypt.Char_1));
                    }
                }
            }
            catch { }
            try
            {
                File.Delete($@"{Path}\Versa-Setup.zip");
            }
            catch { }
        }
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