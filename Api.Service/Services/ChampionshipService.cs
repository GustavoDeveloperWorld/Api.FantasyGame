using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Championship;
using Domain.Interfaces.Services.Match;
using Domain.Interfaces.Services.ChampionshipPoints;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{

    public class ChampionshipService : IChampionshipService
    {

        private IRepository<ChampionshipEntity> _repository;
        private ITimeService _timeService;
        private IMatchService _matcheservice;
        private IChampionshipPointService _pointsChampionshipService;

        public ChampionshipService(IRepository<ChampionshipEntity> repository, ITimeService timeService, IMatchService matcheservice,  IChampionshipPointService pointChampionshipService)
        {
            _repository = repository;
            _timeService = timeService;
            _matcheservice = matcheservice;
            _pointsChampionshipService = pointChampionshipService;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }

        public async Task<ChampionshipEntity> CreateChampionship()
        {
            List<TimeEntity> times = (List<TimeEntity>)await _timeService.GetAll();
            var Championship = new ChampionshipEntity();

            var matches = await _matcheservice.CreateMatches();
            var ChampionshipPoint = _pointsChampionshipService.CalcularPontuacaoChampionship(matches, Championship, times);
            var ChampionshipPointOrdened = ChampionshipPoint.OrderByDescending(x => x.Points);

            Championship.matches = matches;
            Championship.Championship = ChampionshipPointOrdened.ElementAt(0).Time;
            Championship.Vice = ChampionshipPointOrdened.ElementAt(1).Time;
            Championship.Third = ChampionshipPointOrdened.ElementAt(2).Time;

            var ChampionshipCompleted = await _repository.InsertAsync(Championship);

            //Salva pontuacoesChampionship no banco
            foreach (var item in ChampionshipPoint)
            {
                item.Championship = ChampionshipCompleted;
                await _pointsChampionshipService.Post(item);
            }

            //Salva matches no banco
            matches.ForEach(Match => _matcheservice.Post(Match));

            return ChampionshipCompleted;

        }

        public async Task<ChampionshipEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ChampionshipEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ChampionshipEntity> Post(ChampionshipEntity Championship)
        {
            return await _repository.InsertAsync(Championship);
        }

        public async Task<ChampionshipEntity> Put(ChampionshipEntity Championship)
        {
            return await _repository.UpdateAsync(Championship);
        }
    }
}
