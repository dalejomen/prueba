namespace Ibero.Services.Avaya.Domain.Tests.Infrastructure
{
    using System;
    using Ibero.Services.Avaya.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class AvayaDbContextFactory
    {
        public static AvayaDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AvayaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AvayaDbContext(options);

            context.Database.EnsureCreated();

            context.SaveChanges();

            return context;
        }

        public static void Destroy(AvayaDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
