using Bob.Program6.Api.Core.Dao;
using Bob.Program6.Api.Core.Model;
using Bob.Program6.Dao.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Dao
{
    public class RecordDao : IRecordDao
    {
        private IDataAccess _dataAccess;

        public RecordDao(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<Record>> List()
        {
            return await this._dataAccess.Load<Record>("SELECT * FROM TACTIVITY;");
        }

        public async Task Add(Record activity)
        {
            await this._dataAccess.Add<Record>("TACTIVITY", activity);
        }

    }
}
