using Bob.Program6.Api.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Dao
{
    public interface IExceptionDao
    {
        Task<List<SmExceptionDetail>> List();
        Task<ExceptionDetail> Get(int id);
        Task Add(ExceptionDetail exception);
    }
}
