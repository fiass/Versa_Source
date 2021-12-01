using System;
using System.Threading.Tasks;
using Server.Core;
using Server.Database;
using Server.Discord;
using Server.Socket;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ModuleService.UpdateFileData();
            Task.Run(() => SocketService.StartService());
            Task.Run(() => DatabaseService.StartService());
            Task.Run(() => DiscordService.StartService());
            while(true){}
        }
    }
}