using AspNetCoreAngularInMemoryPaging.Api.Models;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngularInMemoryPaging.Api.Data
{
    public class AspNetCoreAngularInMemoryPagingDbContext: DbContext, IAspNetCoreAngularInMemoryPagingDbContext
    {
        public DbSet<Team> Teams { get; private set; }
        public DbSet<Player> Players { get; private set; }
        public AspNetCoreAngularInMemoryPagingDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AspNetCoreAngularInMemoryPagingDbContext).Assembly);
        }
        
    }
}
