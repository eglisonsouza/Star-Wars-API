using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly GenericDA GenericDa;

        public BaseRepository(GenericDA genericDa)
        {
            GenericDa = genericDa;
        }
    }
}