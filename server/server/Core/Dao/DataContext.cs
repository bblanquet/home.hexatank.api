using Microsoft.EntityFrameworkCore;
using server.Core.Model;
using server.Core.Utils;

namespace server.Core.Dao
{
    public class DataContext: DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DataAccessConnection.New().GetConnectionString());
    }
}
