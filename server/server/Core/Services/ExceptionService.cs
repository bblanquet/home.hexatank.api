using server.Core.Dao;
using server.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Core.Services
{
    public class ExceptionService
    {
        private ExceptionDao Dao { get; set; } = new ExceptionDao();
        public async Task<List<ExceptionInfo>> Load()
        {
            return await this.Dao.Select();
        }

        public async Task Add(ExceptionInfo exception)
        {
            await this.Dao.Add(exception);
        }
    }
}
