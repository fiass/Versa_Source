using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Net.WebSockets;
using WebSocketSharp.Server;

namespace Server.Socket
{
    public class ServiceHandler
    {
        public static List<ServiceBase> Services { get; set; } = new List<ServiceBase>();
        public static void SetupServices()
        {
            //Grab all service classes
            Type[] ServiceTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(ServiceBase))).ToArray();
            //Add service classes to list for execution
            for (int i = 0; i < ServiceTypes.Length; i++)
                Services.Add(Activator.CreateInstance(ServiceTypes[i]) as ServiceBase);
        }

        public static void OnOpen(WebSocketContext ctx, WebSocketSessionManager sessions)
        {
            for (int i = 0; i < Services.Count; i++)
            {
                Services[i].Sessions = sessions;
                Services[i].Open(ctx);
            }
        }

        public static void OnClose(CloseEventArgs args)
        {
            for (int i = 0; i < Services.Count; i++)
                Services[i].OnClose(args);
        }

        public static void OnMessage(WebSocketContext ctx, MessageEventArgs args)
        {
            for (int i = 0; i < Services.Count; i++)
            {
                if (args.IsText)
                {
                    try
                    {
                        //Here we check if service type matches message type
                        Structs.Server.Message msg = JsonConvert.DeserializeObject<Structs.Server.Message>(args.Data);
                        if(msg.Type.ToString() == Services[i].Identifier)
                            Services[i].OnMessage(ctx, msg);
                    }
                    catch 
                    {
                        ctx.WebSocket.Send(JsonConvert.SerializeObject(new Structs.Server.Message()
                        {
                            Type = Structs.Server.MessageType.Server,
                            DateSent = DateTime.Now.ToString(),
                            Content = "Invalid Data"
                        }));
                    }
                }
                else
                {
                    ctx.WebSocket.Send(JsonConvert.SerializeObject(new Structs.Server.Message()
                    {
                        Type = Structs.Server.MessageType.Server,
                        DateSent = DateTime.Now.ToString(),
                        Content = "Invalid Data"
                    }));
                }
            }
        }

        public static void OnError(ErrorEventArgs args)
        {
            for (int i = 0; i < Services.Count; i++)
                Services[i].OnError(args);
        }
    }
    
    public class ServiceBase
    {
        public virtual string Identifier { get; set; }
        public WebSocketSessionManager Sessions { get; set; }
        public virtual void Open(WebSocketContext ctx){}
        public virtual void OnClose(CloseEventArgs args){}
        public virtual void OnMessage(WebSocketContext ctx, Structs.Server.Message msg){}
        public virtual void OnError(ErrorEventArgs args){}
    }
}