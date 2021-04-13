using Microsoft.EntityFrameworkCore;
using RssRetriveProcess.Model;

namespace RssRetriveProcess.Context
{
    public class FeedContext: DbContext
    {
        
        public FeedContext(DbContextOptions<FeedContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<RssDto> RssDtos { get; set; }
        public DbSet<RSSNews> RssNewses { get; set; }
        public DbSet<RssRetriveHistory> RssRetriveHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RssDto>(sd =>
            {
                sd.HasNoKey().ToView(null);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}