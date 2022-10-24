using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.ChampionshipPoints
{
    public interface IChampionshipPointService
    {
        Task<ChampionshipPointsEntity> Get(Guid id);
        Task<IEnumerable<ChampionshipPointsEntity>> GetAll();
        Task<ChampionshipPointsEntity> Post(ChampionshipPointsEntity entity);
        Task<ChampionshipPointsEntity> Put(ChampionshipPointsEntity entity);
        Task<bool> Delete(Guid id);
        List<ChampionshipPointsEntity> CalcularPontuacaoChampionship(List<MatchEntity> matches, ChampionshipEntity Championship, List<TimeEntity> times);
    }
}
