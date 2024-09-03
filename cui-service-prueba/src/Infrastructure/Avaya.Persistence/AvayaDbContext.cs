namespace Ibero.Services.Avaya.Persistence
{
    using Ibero.Services.Avaya.Core.Entities;
    using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
    using Microsoft.EntityFrameworkCore;

    public class AvayaDbContext : DbContext, IAvayaDbContext
    {
        public AvayaDbContext(DbContextOptions<AvayaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Person> Ibet_Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AvayaDbContext).Assembly);
        }
    }
}
