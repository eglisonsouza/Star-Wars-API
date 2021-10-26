using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ContextDb ContextDb;

        public BaseRepository(ContextDb contextDb)
        {
            ContextDb = contextDb;
        }
    }
}