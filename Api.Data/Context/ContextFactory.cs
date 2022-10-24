using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var conectionString = "Server=(localdb)\\mssqllocaldb;Database=FantasyGameAPI;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(conectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
