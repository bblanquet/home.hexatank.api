using server.Core.Dao;
using server.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Core.Services
{
    public class ExceptionService
    {
        private ExceptionDao Dao { get; set; } = new ExceptionDao();
        public async Task<List<ExceptionDetail>> List()
        {
            return await this.Dao.List();
        }

        public async Task Add(ExceptionDetail exception)
        {
            await this.Dao.Add(exception);
        }
    }
}
