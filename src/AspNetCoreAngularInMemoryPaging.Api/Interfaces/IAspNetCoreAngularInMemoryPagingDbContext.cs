using AspNetCoreAngularInMemoryPaging.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AspNetCoreAngularInMemoryPaging.Api.Interfaces
{
    public interface IAspNetCoreAngularInMemoryPagingDbContext
    {
        DbSet<Team> Teams { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
