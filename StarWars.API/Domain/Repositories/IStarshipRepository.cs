using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.Entities;

namespace StarWars.API.Domain.Repositories
{
    public interface IStarshipRepository
    {
        IEnumerable<Starship> GetAll();

        Task<bool> Synchronize();
        
    }
} 