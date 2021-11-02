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
    public class PilotDA : BaseDA
    {
        private const string ScriptInsertPilot =
            @"INSERT INTO Pilots (Id, Name, BirthYear, IdPlanet) VALUES (@Id, @Name, @BirthYear, @IdPlanet)";
        
        public PilotDA(IConfiguration configuration) : base(configuration)
        {
        }
        
        public async Task<int> Insert(List<Object> objects)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString: Configuration.GetConnectionString("Db")))
                {
                    return await connection.ExecuteAsync(ScriptInsertPilot, objects);
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