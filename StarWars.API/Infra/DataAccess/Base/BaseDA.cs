using Microsoft.Extensions.Configuration;

namespace StarWars.API.Infra.DataAccess.Base
{
    public class BaseDA
    {
        protected readonly IConfiguration Configuration;

        public BaseDA(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}