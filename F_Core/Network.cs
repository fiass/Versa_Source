using Versa.F_Config;
using Versa.F_Module;
using MelonLoader;
using System;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Versa.F_Output;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CharCrypt;

namespace Versa.F_Core
{
    internal class Server
    {
        internal static bool Role()
        {
            F_Output.CustomConsole.Console(true, "[Server started]");
            try
            {
                Data.ServerRole = Network.DownloadString(ClientProtection.Decrypt(Data._ServerPath));
            }
            catch { return false; }
            F_Output.CustomConsole.Console(true, "[Server finished]");
            return true;
        }
        internal static bool Access()
        {
            F_Output.CustomConsole.Console(true, "[Server checking]");
            string[] data = Data.ServerRole.Split(':');
            foreach (var usr in data)
            {
                if (ClientProtection.Decrypt(usr).Contains(PlayerApi.ID()))
                {

                    F_Output.CustomConsole.Console(true, "[Server return true]");
                    return true;
                }
            }
            F_Output.CustomConsole.Console(true, "[Server return false]");
            return false;
        }
    }
    internal class Network
    {
        static int port = 9999; // порт сервера
      internal static async void Respond(string sendtoserver)
        {
            await Task.Run(() =>
            {
                try
                {
                    IPEndPoint ipPoint = new IPEndPoint(Dns.GetHostAddresses(new string(Versa_Crypt.Char_1))[0], port);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipPoint);
                    string message = sendtoserver;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);
                    data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);
                    Console.WriteLine("[Server respond: " + builder.ToString() + "]");
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch { CustomConsole.Console(true, "Network.cs [Respond] " + "Server shutdown"); }
            });
        }

        private static WebClient wc = new WebClient();
        internal static void OpenDoc()
        {
            System.Diagnostics.Process.Start("https://fiass.github.io/Versa/function.html");
        }
        internal static string DownloadString(string _url)
        {
            return wc.DownloadString(_url);
        }
        internal static bool DownloadFile(string _url, string _name)
        {
            bool _c = false;
            try { wc.DownloadFile(_url, _name); _c = true; } catch { }
            return _c;
        }
        internal static void DownloadIconPack()
        {
            F_Output.CustomConsole.Console(true, "[ResourceHandler started]");
            try
            {
                Data.Textures[0] = ResourceHandler.LoadTexture("Icon.png");
                Data.Textures[1] = ResourceHandler.LoadTexture("Folder.png");
                Data.Textures[2] = ResourceHandler.LoadTexture("Moon.png");
                Data.Textures[3] = ResourceHandler.LoadTexture("Optimization.png");
                Data.Textures[4] = ResourceHandler.LoadTexture("Ownership.png");
                Data.Textures[5] = ResourceHandler.LoadTexture("Fly.png");
                Data.Textures[6] = ResourceHandler.LoadTexture("Speed.png");
                Data.Textures[7] = ResourceHandler.LoadTexture("DL.png");
                Data.Textures[8] = ResourceHandler.LoadTexture("Fov.png");
                Data.Textures[9] = ResourceHandler.LoadTexture("Esp.png");
                Data.Textures[10] = ResourceHandler.LoadTexture("Sit.png");
                Data.Textures[11] = ResourceHandler.LoadTexture("Lewd.png");
                Data.Textures[12] = ResourceHandler.LoadTexture("Teleport.png");
                Data.Textures[13] = ResourceHandler.LoadTexture("Post.png");
                Data.Textures[14] = ResourceHandler.LoadTexture("Color.png");
                Data.Textures[15] = ResourceHandler.LoadTexture("Join.png");
                Data.Textures[16] = ResourceHandler.LoadTexture("Copy.png");
                Data.Textures[17] = ResourceHandler.LoadTexture("Preview.png");
                Data.Textures[18] = ResourceHandler.LoadTexture("Blockportals.png");
                Data.Textures[19] = ResourceHandler.LoadTexture("Log.png");
                Data.Textures[20] = ResourceHandler.LoadTexture("Jump.png");
                Data.Textures[21] = ResourceHandler.LoadTexture("Moveblock.png");
                Data.Textures[22] = ResourceHandler.LoadTexture("chair.png");
                Data.Textures[23] = ResourceHandler.LoadTexture("Anticrash.png");
                Data.Textures[24] = ResourceHandler.LoadTexture("Flashlight.png");
                Data.renderTexture = ResourceHandler.LoadRenderTexture("RenderCam.renderTexture");
                Data.Materials[0] = ResourceHandler.LoadMaterial("RenderCam.mat");
                Data.GameObjects[0] = ResourceHandler.LoadGameobject("Camera.prefab");
                Data.VersaStats = ResourceHandler.LoadGameobject("Stats.prefab");
                Data.Textures[96] = ResourceHandler.LoadTexture("MenuBackground.png");
                Data.Textures[98] = ResourceHandler.LoadTexture("Sphere.png");
                Data.Textures[97] = ResourceHandler.LoadTexture("Private.png");
                Data.Textures[50] = ResourceHandler.LoadTexture("Doc.png");

            }
            catch (Exception e) { CustomConsole.Console(true, "Network.cs [DownloadIconPack] " + e.Message); }
            F_Output.CustomConsole.Console(true, "[ResourceHandler finished]");
        }
    }
}
