using Bob.Program6.Api.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Services
{
    public interface IRecordService
    {
        Task<List<Record>> List();
        Task Add(Record activity);
    }
}
