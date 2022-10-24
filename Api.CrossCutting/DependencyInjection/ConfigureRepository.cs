using Microsoft.Extensions.DependencyInjection;
using Data.Repository;
using Domain.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

             serviceCollection.AddDbContext<MyContext>                 (
                 options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FantasyGameAPI;Trusted_Connection=True;MultipleActiveResultSets=true")
             );
        }
    }
}
