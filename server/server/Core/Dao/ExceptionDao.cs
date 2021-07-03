using server.Core.Model;
using server.Core.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Core.Dao
{
    public class ExceptionDao
    {
        public async Task<List<ExceptionDetail>> List()
        {
            return await DataAccess.Load<ExceptionDetail>("SELECT * FROM TEXCEPTION;");
        }

        internal async Task Add(ExceptionDetail exception)
        {
            await DataAccess.Add<ExceptionDetail>("TEXCEPTION", exception);
        }
    }
}
