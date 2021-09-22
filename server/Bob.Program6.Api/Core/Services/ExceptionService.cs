using Bob.Program6.Api.Core.Dao;
using Bob.Program6.Api.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Services
{
    public class ExceptionService:IExceptionService
    {
        private IExceptionDao _dao;

        public ExceptionService(IExceptionDao dao)
        {
            _dao = dao;
        }

        public async Task<List<LightErrorDetails>> List()
        {
            return await this._dao.List();
        }

        public async Task<ErrorDetails> Get(int id)
        {
            return await this._dao.Get(id);
        }

        public async Task Add(ErrorDetails exception)
        {
            exception.Date = System.DateTime.Now;
            await this._dao.Add(exception);
        }
    }
}
