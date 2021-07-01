using server.Core.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using server.Dao;

namespace server.Core
{
    public class ActivityService
    {
        private ActivityDao Dao { get; set; } = new ActivityDao();
        public async Task<List<Activity>> Load()
        {
            return await this.Dao.Select();

        }
    }
}
