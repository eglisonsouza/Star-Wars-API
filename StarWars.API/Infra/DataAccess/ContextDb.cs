using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

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
        
    }
}