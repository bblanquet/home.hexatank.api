using Bob.Program6.Api.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Dao
{
    public interface IExceptionDao
    {
        Task<List<LightErrorDetails>> List();
        Task<ErrorDetails> Get(int id);
        Task Add(ErrorDetails exception);
    }
}
