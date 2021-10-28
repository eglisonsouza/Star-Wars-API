using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.API.Domain.ViewModels;

namespace StarWars.API.Domain.Services
{
    public interface IPlanetService
    {
        Task<List<PlanetViewModel>> Synchronize();
    }
}