using Npgsql;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Utils
{
    public class DataAccess : IDataAccess
    {
        private  NpgsqlConnection Connection;
        public async Task Connecting()
        {
            var connString = DataAccessConnection.New().GetConnectionString();
            Connection = new NpgsqlConnection(connString);
            await Connection.OpenAsync();
        }

        public bool HasConnection()
        {
            return Connection != null && Connection.State == System.Data.ConnectionState.Open;
        }

        public async Task<NpgsqlConnection> GetConnection()
        {
            if (!HasConnection())
            {
                await Connecting();
            }
            return Connection;
        }
    }
}
