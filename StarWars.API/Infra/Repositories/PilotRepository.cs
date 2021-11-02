using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.API.Domain.Entities;
using StarWars.API.Domain.Repositories;
using StarWars.API.Domain.Services;
using StarWars.API.Domain.ViewModels;
using StarWars.API.Infra.DataAccess;

namespace StarWars.API.Infra.Repositories
{
    public class PilotRepository : BaseRepository, IPilotRepository
    {
        private readonly IPilotSynchronize _pilotSynchronize;
        private readonly IStarshipPilotRepository _starshipPilotRepository;
        
        private const string ScriptInsert =
            @"INSERT INTO Pilots (Id, Name, BirthYear, IdPlanet) VALUES (@Id, @Name, @BirthYear, @IdPlanet)";

        
        public PilotRepository(GenericDA genericDa, IPilotSynchronize pilotSynchronize,
            IStarshipPilotRepository starshipPilotRepository) : base(genericDa)
        {
            _pilotSynchronize = pilotSynchronize;
            _starshipPilotRepository = starshipPilotRepository;
        }

        public async Task<bool> Synchronize()
        {
            try
            {
                GenericDa.Insert<Object>(
                    objects: (await _pilotSynchronize.Synchronize()).Select(ConvertToPilot).ToList(),
                    sql: ScriptInsert);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            /*try
            {
                ContextDb?.Insert<Pilot>(
                    objects: (await _pilotSynchronize.Synchronize()).Select(ConvertToPilot).ToList(), 
                    sql: ScriptInsert);
                
                    (await _pilotSynchronize.Synchronize()).ForEach(pilot =>
                    {
                        ContextDb?.Insert<Pilot>(
                            sql: ScriptInsert,
                            param: new
                            {
                                Id = pilot.GetId(),
                                Name = pilot.Name,
                                BirthYear = pilot.BirthYear,
                                IdPlanet = pilot.GetIdPlanet()
                            });
                        _starshipPilotRepository.AssociateShipPilot(idPilot: pilot.GetId(),
                            idStarships: pilot.GetIdStarships());
                    });

                return true;
            }
            catch (Exception e)
            {
                throw;
            }*/
            return true;
        }

        private static Object ConvertToPilot(PilotViewModel pilotViewModel)
        {
            return new
            {
                Id = pilotViewModel.GetId(),
                Name = pilotViewModel.Name,
                BirthYear = pilotViewModel.BirthYear,
                IdPlanet = pilotViewModel.GetIdPlanet()
            };
        } 
    }
}