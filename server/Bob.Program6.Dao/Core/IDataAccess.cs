using Npgsql;
using System.Threading.Tasks;

namespace Bob.Program6.Dao.Core
{
    public interface IDataAccess
    {
        Task Connecting();
        bool HasConnection();
        Task<NpgsqlConnection> GetConnection();
    }
}
