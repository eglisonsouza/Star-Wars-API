using System.Threading.Tasks;
using StarWars.API.Domain.Entities;

namespace StarWars.API.Domain.Repositories
{
    public interface IPilotRepository
    {
        Task<bool> Synchronize();

    }
}