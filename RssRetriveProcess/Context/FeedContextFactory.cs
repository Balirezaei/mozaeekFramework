using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RssRetriveProcess.Context
{
    public class FeedContextFactory : IDesignTimeDbContextFactory<FeedContext>
    {
        public FeedContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FeedContext>();

            optionsBuilder.UseSqlServer("integrated Security=True;Initial Catalog=CoreDomain;Data Source=.");
          
            return new FeedContext(optionsBuilder.Options);
        }
    }
}