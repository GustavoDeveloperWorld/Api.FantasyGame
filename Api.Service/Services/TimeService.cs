using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Time;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TimeService : ITimeService
    {
        private IRepository<TimeEntity> _repository;

        public TimeService(IRepository<TimeEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }

        public async Task<TimeEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<TimeEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<TimeEntity> Post(TimeEntity time)
        {
            return await _repository.InsertAsync(time);
        }

        public async Task<TimeEntity> Put(TimeEntity time)
        {
            return await _repository.UpdateAsync(time);
        }

        public async Task<List<TimeEntity>> GetTimes(PageParameters ParametersPage)
        {
            return await _repository.GetPagete(ParametersPage);
        }

        public async Task<List<TimeEntity>> FindAll(string name)
        {
            return await _repository.FindAll()
                .Where(time => time.name == name)
                .ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _repository.Count();
        }
    }
}
