using server.Core.Model;
using server.Core.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Core.Dao
{
    public class ExceptionDao
    {
        public async Task<List<ExceptionInfo>> Select()
        {
            return await DataAccess.Load<ExceptionInfo>("SELECT * FROM TEXCEPTION;");
        }

        internal async Task Add(ExceptionInfo exception)
        {
            await DataAccess.Add<ExceptionInfo>("TEXCEPTION", exception);
        }
    }
}
