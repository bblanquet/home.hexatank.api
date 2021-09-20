using Bob.Program6.Api.Core.Model;
using Bob.Program6.Api.Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Dao
{
    public class ExceptionDao:IExceptionDao
    {
        private IDataAccess _dataAccess;

        public ExceptionDao(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<SmExceptionDetail>> List()
        {
            return await this._dataAccess.Load<SmExceptionDetail>("SELECT Id, Date, Name FROM TEXCEPTION;");
        }

        public async Task<ExceptionDetail> Get(int id)
        {
            var result =  await this._dataAccess.Load<ExceptionDetail>($"SELECT * FROM TEXCEPTION where Id = {id};");
            return result[0];
        }

        public async Task Add(ExceptionDetail exception)
        {
            await this._dataAccess.Add<ExceptionDetail>("TEXCEPTION", exception);
        }
    }
}
