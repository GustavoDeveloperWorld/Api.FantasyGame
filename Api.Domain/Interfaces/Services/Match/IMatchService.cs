using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Match
{
    public interface IMatchService
    {
        Task<MatchEntity> Get(Guid id);
        Task<IEnumerable<MatchEntity>> GetAll();
        Task<MatchEntity> Post(MatchEntity entity);
        Task<MatchEntity> Put(MatchEntity entity);
        Task<bool> Delete(Guid id);
        Task<List<MatchEntity>> CreateMatches();
    }
}
