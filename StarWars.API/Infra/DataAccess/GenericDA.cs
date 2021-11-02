using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using StarWars.API.Infra.DataAccess.Base;

namespace StarWars.API.Infra.DataAccess
{
    public class GenericDA : BaseDA
    {
        
        public GenericDA(IConfiguration configuration) : base(configuration)
        {
        }
        
        public IEnumerable<T> Get<T>(string sql = "", object param = null)
        {
            if (String.IsNullOrEmpty(sql)) sql = $"SELECT * FROM {typeof(T).Name}s";

            using (MySqlConnection connection = new MySqlConnection(connectionString: Configuration.GetConnectionString("Db")))
            {
                return connection.Query<T>(sql: sql, param: param);
            }
        }
        
        public async Task<Object> GetOne<T>(string sql = "", object param = null)
        {
            if (String.IsNullOrEmpty(sql)) sql = $"SELECT * FROM {typeof(T).Name}s";

            using (MySqlConnection connection = new MySqlConnection(connectionString: Configuration.GetConnectionString("Db")))
            {
                return await connection.ExecuteScalarAsync<T>(sql: sql, param: param);
            }
        }
        
        public async Task<int> Insert<T>(List<T> objects, string sql = null)
        {
            try
            {
                if (string.IsNullOrEmpty(sql))
                {
                    sql = $@"
                        INSERT INTO {typeof(T).Name}s ({String.Join(",", typeof(T).GetProperties().Select(atr => atr.Name))}) VALUES ({String.Join(",", typeof(T).GetProperties().Select(atr => $"@{atr.Name}"))})";
                }
                
                using (MySqlConnection connection = new MySqlConnection(connectionString: Configuration.GetConnectionString("Db")))
                {
                    return await connection.ExecuteAsync(sql, objects);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<int> Insert<T>(T param, string sql = null)
        {
            try
            {
                if (string.IsNullOrEmpty(sql))
                {
                    sql = $@"INSERT INTO {typeof(T).Name}s ({String.Join(",", typeof(T).GetProperties().Select(atr => atr.Name))})
                    VALUES ({String.Join(",", typeof(T).GetProperties().Select(atr => $"@{atr.Name}"))})";
                }
                
                using (MySqlConnection connection = new MySqlConnection(connectionString: Configuration.GetConnectionString("Db")))
                {
                    return await connection.ExecuteAsync(sql, param);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}