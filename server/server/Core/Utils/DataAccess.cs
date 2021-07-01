using Dapper;
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
            using (var conn = await GetConnection())
            {
                var query = GetQuery<T>(tablename);
                _ = await conn.ExecuteScalarAsync<T>(query, value);
            }
        }

        private static string GetQuery<T>(string tablename)
        {
            var props = string.Join(",", MetaReader.GetProps<T>());
            var tags = string.Join(",", MetaReader.GetTags<T>());
            var command = $"INSERT INTO {tablename} ({props}) VALUES ({tags});";
            return command;
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
                            foreach (var prop in MetaReader.GetProps<T>())
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
