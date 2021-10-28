using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using StarWars.API.Domain.Entities;

namespace StarWars.API.Infra.DataAccess
{
    public class ContextDb
    {
        private readonly IConfiguration _configuration;

        public ContextDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IEnumerable<T> Get<T>(string sql = "", object param = null)
        {
            if (String.IsNullOrEmpty(sql)) sql = $"SELECT * FROM {typeof(T).Name}s";

            using (MySqlConnection connection = new MySqlConnection(connectionString: _configuration.GetConnectionString("Db")))
            {
                return connection.Query<T>(sql: sql, param: param);
            }
        }
        
        public async Task<int> Insert<T>(T t)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString: _configuration.GetConnectionString("Db")))
            {
                return await connection.ExecuteAsync($@"INSERT INTO {typeof(T).Name}s
                                                            ({String.Join(",", typeof(T).GetProperties().Select(atr => atr.Name))})
                                                        VALUES ({String.Join(",", typeof(T).GetProperties().Select(atr => $"@{atr.Name}"))})", t);
                
            }
        }
        
    }
}