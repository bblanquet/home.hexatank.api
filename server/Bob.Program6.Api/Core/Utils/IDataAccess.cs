using Npgsql;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Utils
{
    public interface IDataAccess
    {
        Task Connecting();
        bool HasConnection();
        Task<NpgsqlConnection> GetConnection();
    }
}
