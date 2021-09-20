
using System;

namespace Bob.Program6.Api.Core.Utils
{
    public struct DataAccessConnection
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
 
        public string GetConnectionString()
        {
            return $"Host={this.Host};Port={this.Port};Username={this.Username};Password={this.Password};Database={this.Database}";
        }
        public static DataAccessConnection New()
        {
            return new DataAccessConnection()
            {
                Host = Environment.GetEnvironmentVariable("HOST"),
                Port = int.Parse(Environment.GetEnvironmentVariable("PORT")),
                Username = Environment.GetEnvironmentVariable("USERNAME"),
                Password = Environment.GetEnvironmentVariable("PASSWORD"),
                Database = Environment.GetEnvironmentVariable("DATABASE"),
            };
        }
    }

}
