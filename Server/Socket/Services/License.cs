using System;
using System.IO;
using Newtonsoft.Json;
using Server.Core;
using Server.Database;
using WebSocketSharp.Net.WebSockets;

namespace Server.Socket.Services
{
    public class LicenseService : ServiceBase
    {
        public override string Identifier { get; set; } = "License";

        public override void OnMessage(WebSocketContext ctx, Structs.Server.Message msg)
        {
            //Send assembly data if license is valid
            //This works as web load
            Structs.Server.LicenseData licenseData = JsonConvert.DeserializeObject<Structs.Server.LicenseData>(msg.Content);
            if (DatabaseService.Licenses.Exists(x => x.Key == licenseData.Key))
            {
                Logger.Log("License", $"Sending assembly to valid license: {licenseData.Key}:{licenseData.UserID}", ConsoleColor.Green);
                ctx.WebSocket.Send(JsonConvert.SerializeObject(new Structs.Server.Message()
                {
                    Type = Structs.Server.MessageType.License,
                    DateSent = DateTime.Now.ToString(),
                    //Here we read file data and send message content
                    Content = Convert.ToBase64String(Core.ModuleService.CachedFileData)
                }));
            }
            else
            {
                Logger.Log("License", $"Invalid license from: {licenseData.Key}:{licenseData.UserID}", ConsoleColor.Red);
                ctx.WebSocket.Send(JsonConvert.SerializeObject(new Structs.Server.Message()
                {
                    Type = Structs.Server.MessageType.Server,
                    DateSent = DateTime.Now.ToString(),
                    Content = "Invalid Data"
                }));
            }
        }
    }
}