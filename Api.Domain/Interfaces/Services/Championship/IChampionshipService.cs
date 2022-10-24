using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Championship
{
    public interface IChampionshipService
    {
        Task<ChampionshipEntity> Get(Guid id);
        Task<IEnumerable<ChampionshipEntity>> GetAll();
        Task<ChampionshipEntity> Post(ChampionshipEntity entity);
        Task<ChampionshipEntity> Put(ChampionshipEntity entity);
        Task<bool> Delete(Guid id);

        Task<ChampionshipEntity> CreateChampionship();
    }
}
