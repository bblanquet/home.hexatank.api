using System;

namespace server.Core.Model
{
    public class ExceptionDetail
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string StackTrace { get; set; }
        public string Content { get; set; }
    }
}
