using server.Core.Model;
using server.Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Core.Dao
{
    public class ExceptionDao
    {
        public async Task<List<SmExceptionDetail>> List()
        {
            return await DataAccess.Load<SmExceptionDetail>("SELECT Id, Date, Name FROM TEXCEPTION;");
        }

        public async Task<ExceptionDetail> Get(int id)
        {
            var result =  await DataAccess.Load<ExceptionDetail>($"SELECT * FROM TEXCEPTION where Id = {id};");
            return result[0];
        }

        internal async Task Add(ExceptionDetail exception)
        {
            await DataAccess.Add<ExceptionDetail>("TEXCEPTION", exception);
        }
    }
}
