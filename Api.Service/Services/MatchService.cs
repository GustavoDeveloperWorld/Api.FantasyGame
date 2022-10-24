using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Match;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MatchService : IMatchService
    {
        private IRepository<MatchEntity> _repository;
        private ITimeService _timeService;

        public MatchService(IRepository<MatchEntity> repository, ITimeService timeService)
        {
            _repository = repository;
            _timeService = timeService;
        }

        public async Task<List<MatchEntity>> CreateMatches()
        {
            var times = await _timeService.GetAll();
            List<MatchEntity> matches = new List<MatchEntity>();
            
            foreach (var time1 in times)
            {
                foreach (var time2 in times)
                {
                    if (time1 != time2 && !matches.Any(x => x.Time1 == time2 && x.Time2 == time1))
                    {
                        var Match = new MatchEntity();
                        Match.Time1 = time1;
                        Match.Time2 = time2;

                        Random rnd = new Random();
                        Match.Goals1 = rnd.Next(1, 7);
                        Match.Goals2 = rnd.Next(1, 7);

                        matches.Add(Match);
                    }
                }
            }

            return (matches);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }

        public async Task<MatchEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<MatchEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<MatchEntity> Post(MatchEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<MatchEntity> Put(MatchEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }        
        

    }
}
