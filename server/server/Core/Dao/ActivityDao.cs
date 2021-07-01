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
            var result = new List<Activity>();
            try
            {
                result = await DataAccess.Load<Activity>("SELECT * FROM TACTIVITY;");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return result;

        }
    }
}
