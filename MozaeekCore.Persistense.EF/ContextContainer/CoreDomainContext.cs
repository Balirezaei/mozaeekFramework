using Microsoft.EntityFrameworkCore;
using MozaeekCore.Domain;
using MozaeekCore.ViewModel;

namespace MozaeekCore.Persistense.EF
{
    public class CoreDomainContext : DbContext
    {
        public CoreDomainContext()
        { }

        public CoreDomainContext(DbContextOptions<CoreDomainContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Label> Labels { get; set; }

    }
}