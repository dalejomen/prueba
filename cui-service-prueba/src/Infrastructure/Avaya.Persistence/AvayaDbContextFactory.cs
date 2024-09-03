namespace Ibero.Services.Avaya.Persistence
{
    using Ibero.Services.Avaya.Persistence.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    class AvayaDbContextFactory : DesignTimeDbContextFactoryBase<AvayaDbContext>
    {
        protected override AvayaDbContext CreateNewInstance(DbContextOptions<AvayaDbContext> options)
        {
            return new AvayaDbContext(options);
        }
    }
}
