using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Core.Utils
{
    public static class DataAccess
    {
        private static NpgsqlConnection Connection;
        private static async Task Connecting()
        {
            var connString = DataAccessConnection.New().GetConnectionString();
            Console.WriteLine($"CONNECTING {connString}");
            Connection = new NpgsqlConnection(connString);
            await Connection.OpenAsync();
            Console.WriteLine($"CONNECTED {connString}");
        }

        private static bool HasConnection()
        {
            return Connection != null && Connection.State == System.Data.ConnectionState.Open;
        }

        private static async Task<NpgsqlConnection> GetConnection()
        {
            if (!HasConnection())
            {
                await Connecting();
            }
            return Connection;
        }

        public static async Task Add<T>(string tablename, T value)
        {
            var properties = string.Join(",", MetaReader.GetProperties<T>());
            var values = string.Join(",", MetaReader.GetValues<T>(value)) ;
            var command = $"INSERT INTO {tablename} VALUES ({properties}) ({values});";
            using (var conn = await GetConnection())
            {
                await using (var cmd = new NpgsqlCommand(command, conn))
                {
                    _ = await cmd.ExecuteReaderAsync();
                }
            }
        }

        public static async Task<List<T>> Load<T>(string command)
        {
            var result = new List<T>();
            using(var conn = await GetConnection())
            {
                await using (var cmd = new NpgsqlCommand(command, conn))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = Activator.CreateInstance<T>();
                            foreach (var prop in MetaReader.GetProperties<T>())
                            {
                                MetaReader.SetPropety(item, prop, reader[prop]);
                            }
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }
    }
}
