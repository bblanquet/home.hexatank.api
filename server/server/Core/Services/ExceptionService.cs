using server.Core.Dao;
using server.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Core.Services
{
    public class ExceptionService
    {
        private ExceptionDao Dao { get; set; } = new ExceptionDao();
        public async Task<List<SmExceptionDetail>> List()
        {
            return await this.Dao.List();
        }

        public async Task<ExceptionDetail> Get(int id)
        {
            return await this.Dao.Get(id);
        }

        public async Task Add(ExceptionDetail exception)
        {
            await this.Dao.Add(exception);
        }
    }
}
