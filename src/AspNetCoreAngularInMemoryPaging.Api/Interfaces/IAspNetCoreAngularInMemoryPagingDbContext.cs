using AspNetCoreAngularInMemoryPaging.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AspNetCoreAngularInMemoryPaging.Api.Interfaces
{
    public interface IAspNetCoreAngularInMemoryPagingDbContext
    {
        DbSet<Team> Teams { get; }
        DbSet<Player> Players { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
