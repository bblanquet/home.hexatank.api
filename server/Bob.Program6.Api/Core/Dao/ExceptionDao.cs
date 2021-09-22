using Bob.Program6.Api.Core.Model;
using Bob.Program6.Dao.Core;
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

        public async Task<List<LightErrorDetails>> List()
        {
            return await this._dataAccess.Load<LightErrorDetails>("SELECT Id, Date, Name FROM TEXCEPTION;");
        }

        public async Task<ErrorDetails> Get(int id)
        {
            var result =  await this._dataAccess.Load<ErrorDetails>($"SELECT * FROM TEXCEPTION where Id = {id};");
            return result[0];
        }

        public async Task Add(ErrorDetails exception)
        {
            await this._dataAccess.Add<ErrorDetails>("TEXCEPTION", exception);
        }
    }
}
