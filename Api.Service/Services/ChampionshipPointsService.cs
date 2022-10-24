using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.ChampionshipPoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ChampionshipPointsService : IChampionshipPointService
    {
        private IRepository<ChampionshipPointsEntity> _repository;

        public ChampionshipPointsService(IRepository<ChampionshipPointsEntity> repository)
        {
            _repository = repository;
        }

        
        public List<ChampionshipPointsEntity> CalcularPontuacaoChampionship(List<MatchEntity> matches, ChampionshipEntity Championship, List<TimeEntity> times)
        {
            List<ChampionshipPointsEntity> PointsChampionship = new List<ChampionshipPointsEntity>();

            //Gera lista de ChampionshipPoints com times
            foreach (var time in times)
            {
                var ChampionshipPoints = new ChampionshipPointsEntity();
                ChampionshipPoints.Time = time;
                PointsChampionship.Add(ChampionshipPoints);
            }

            //Calcula a pontuação de cada time
            foreach (var Match in matches)
            {
                if (Match.Goals1 > Match.Goals2)
                {
                    var test = PointsChampionship.Find(x => x.Time == Match.Time1);

                    test.Points += 3;
                }
                else if (Match.Goals1 < Match.Goals2)
                {
                    var test = PointsChampionship.Find(x => x.Time == Match.Time2);

                    test.Points += 3;
                }
                else
                {
                    var test = PointsChampionship.Find(x => x.Time == Match.Time2);
                    test.Points += 1;

                    test = PointsChampionship.Find(x => x.Time == Match.Time1);
                    test.Points += 1;
                }
            }
            return (PointsChampionship);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }

        public async Task<ChampionshipPointsEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ChampionshipPointsEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ChampionshipPointsEntity> Post(ChampionshipPointsEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }   


        public async Task<ChampionshipPointsEntity> Put(ChampionshipPointsEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
