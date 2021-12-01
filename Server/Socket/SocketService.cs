using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server.Socket
{
    public class SocketService
    {
        public static WebSocketServer wssv { get; set; }
        public static async Task StartService()
        {
            ServiceHandler.SetupServices();
            wssv = new WebSocketServer (8123);
            wssv.Log.Output = (data, s) => { }; 
            wssv.AddWebSocketService<VersaMasterService> ("/Versa");
            wssv.Start ();
            await Task.Delay(-1);
        }
    }

    internal class VersaMasterService : WebSocketBehavior
    {
        protected override void OnOpen() => ServiceHandler.OnOpen(Context, Sessions);
        
        protected override void OnClose(CloseEventArgs e) => ServiceHandler.OnClose(e);

        protected override void OnMessage(MessageEventArgs e) => ServiceHandler.OnMessage(Context, e);

        protected override void OnError(ErrorEventArgs e) => ServiceHandler.OnError(e);



    }
}