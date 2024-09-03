namespace Ibero.Services.Avaya.Domain.Infrastructure.Abstract
{
    using Ibero.Services.Avaya.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAvayaDbContext
    {
        DbSet<Person> Person { get; set; }

        DbSet<Person> Ibet_Person { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
