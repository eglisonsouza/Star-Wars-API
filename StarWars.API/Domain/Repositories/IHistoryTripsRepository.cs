using System;
using System.Threading.Tasks;
using StarWars.API.Domain.Arguments.HistoryTrips;

namespace StarWars.API.Domain.Repositories
{
    public interface IHistoryTripsRepository
    {
        Task<int> RegisterExit(RegisterRequest registerRequest);
        Task<int> RegisterArrival(RegisterRequest registerRequest);
    }
}