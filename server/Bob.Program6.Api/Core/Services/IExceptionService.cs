using Bob.Program6.Api.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Services
{
    public interface IExceptionService
    {
        Task<List<SmExceptionDetail>> List();
        Task<ExceptionDetail> Get(int id);
        Task Add(ExceptionDetail exception);
    }
}
