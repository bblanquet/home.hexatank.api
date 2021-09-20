using Bob.Program6.Api.Core.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using Bob.Program6.Api.Core.Dao;
using Bob.Program6.Api.Core.Services;

namespace Bob.Program6.Api.Core
{
    public class RecordService:IRecordService
    {
        private IRecordDao _dao;

        public RecordService(IRecordDao dao)
        {
            _dao = dao;
        }

        public async Task<List<Record>> List()
        {
            return await this._dao.List();
        }

        public async Task Add(Record activity)
        {
            await this._dao.Add(activity);
        }
    }
}
