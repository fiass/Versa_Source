using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Module
{
    class LogData
    {
        public static void World()
        {
            try
            {
                string logFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Logs\\";
                if (!File.Exists(logFilePath + "WorldHistory.txt"))
                    File.Create(logFilePath + "WorldHistory.txt");

                File.AppendAllText(logFilePath + "/WorldHistory.txt", "\n \""+ GameApi.currentRoom.shortName + "\": { \n" + $"  \"JoinTime\":\"{DateTime.Now}\", \n" + $"  \"World Name\":\"{GameApi.currentRoom.world.name}\", \n" + $"  \"Author\":\"{GameApi.currentRoom.world.authorName}\", \n" + $"  \"ID\":\"{GameApi.currentRoom.id}\" \n"+"}");//[{DateTime.Now}][({GameApi.currentRoom.world.name}) Author: ({GameApi.currentRoom.world.authorName})] {GameApi.currentRoom.id}\n \n"
            }
            catch(Exception e) { CustomConsole.Console(true, "LogData.cs [World] " + e.Message); }
        }
    }
}
