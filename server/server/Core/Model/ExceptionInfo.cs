using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Core.Model
{
    public class ExceptionInfo
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string StackTrace { get; set; }
        public Object Content { get; set; }
    }
}
