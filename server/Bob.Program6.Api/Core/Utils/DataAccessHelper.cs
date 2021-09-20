using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Utils
{
    public static class DataAccessHelper
    {
        public static async Task Add<T>(this IDataAccess val, string tablename, T value)
        {
            using (var conn = await val.GetConnection())
            {
                var query = GetInsertionQuery<T>(tablename);
                _ = await conn.ExecuteScalarAsync<T>(query, value);
            }
        }

        public static async Task Execute<T>(this IDataAccess val, string query, T value)
        {
            using (var conn = await val.GetConnection())
            {
                _ = await conn.ExecuteScalarAsync<T>(query, value);
            }
        }

        internal static async Task Update<T>(this IDataAccess val, string tablename, T value, Expression<Func<T, string>> where)
        {
            using (var conn = await val.GetConnection())
            {
                var command = GetUpdateQuery<T>(tablename, where);
                await conn.ExecuteScalarAsync<T>(command, value);
            }
        }


        public static async Task<List<T>> Load<T>(this IDataAccess val, string command)
        {
            var result = new List<T>();
            using (var conn = await val.GetConnection())
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

        public static async Task<List<T>> LoadAll<T>(this IDataAccess val, string tablename)
        {
            var result = new List<T>();
            using (var conn = await val.GetConnection())
            {
                await using (var cmd = new NpgsqlCommand(@$"SELECT * FROM {tablename};", conn))
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


        private static string GetInsertionQuery<T>(string tablename)
        {
            var props = string.Join(",", MetaReader.GetProps<T>());
            var tags = string.Join(",", MetaReader.GetTags<T>());
            var command = $"INSERT INTO {tablename} ({props}) VALUES ({tags});";
            return command;
        }

        private static string GetUpdateQuery<T>(string tablename, Expression<Func<T, string>> v)
        {
            var wherePropName = MetaReader.GetMemberName(v);
            return $"UPDATE {tablename} SET {String.Join(",", MetaReader.GetPropsAndTags<T>())} WHERE {wherePropName} = @{wherePropName}";
        }
    }
}
