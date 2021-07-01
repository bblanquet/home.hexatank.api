using System;

namespace server.Core.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string SocketId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
    }
}
