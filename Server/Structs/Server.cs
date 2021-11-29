namespace Server.Structs
{
    public class Server
    {
        public struct Message
        {
            public MessageType Type { get; set; }
            public string DateSent { get; set; }
            public string Content { get; set; }
        }
        
        public enum MessageType
        {
            License,
            Server,
            Unknown
        }
        
        public struct LicenseData
        {
            public string UserID { get; set; }
            public string Key { get; set; }
        }
    }
}