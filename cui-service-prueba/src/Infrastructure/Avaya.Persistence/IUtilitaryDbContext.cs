namespace Ibero.Services.Utilitary.Domain.Infrastructure.Abstract
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUtilitaryDbContext
    {
      

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}