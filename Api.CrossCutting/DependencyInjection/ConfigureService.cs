using Domain.Interfaces.Services.Championship;
using Domain.Interfaces.Services.Match;
using Domain.Interfaces.Services.ChampionshipPoints;
using Domain.Interfaces.Services.Time;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {

        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITimeService, TimeService>();
            serviceCollection.AddTransient<IChampionshipService, ChampionshipService>();
            serviceCollection.AddTransient<IMatchService, MatchService>();
            serviceCollection.AddTransient<IChampionshipPointService, ChampionshipPointsService>();
        }
    }
}
