using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Utils
{
    public static class Logger
    {
        public static void Log(LogKind kind, string message) {
            Console.WriteLine($"[${DateTime.Now.ToString("f")}] [{kind}] ${message}");
        }
    }

    public enum LogKind { 
        Info,
        Debug,
        Error
    }
}
