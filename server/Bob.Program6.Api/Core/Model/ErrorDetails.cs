using System;

namespace Bob.Program6.Api.Core.Model
{
    public class ErrorDetails
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string StackTrace { get; set; }
        public string Content { get; set; }
    }
}
