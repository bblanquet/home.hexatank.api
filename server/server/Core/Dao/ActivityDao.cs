using server.Core.Model;
using server.Core.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Dao
{
    public class ActivityDao
    {
        public async Task<List<Activity>> Select()
        {
            return await DataAccess.Load<Activity>("SELECT * FROM TACTIVITY;");

        }
    }
}
