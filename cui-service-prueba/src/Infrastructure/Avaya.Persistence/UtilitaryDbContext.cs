namespace Ibero.Services.Utilitary.Persistence
{
    using Ibero.Services.Utilitary.Domain.Infrastructure.Abstract;
    using Microsoft.EntityFrameworkCore;

    public class UtilitaryDbContext : DbContext, IUtilitaryDbContext
    {
        public UtilitaryDbContext(DbContextOptions<UtilitaryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UtilitaryDbContext).Assembly);
        }
    }
}
