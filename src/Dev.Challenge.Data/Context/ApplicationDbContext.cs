using Dev.Challenge.Domain.Abstractions;
using Dev.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dev.Challenge.Data.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Project> Projects{ get; set; }
        public DbSet<Historic> Historics{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .EnableSensitiveDataLogging()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                 p => p.EnableRetryOnFailure(
                     maxRetryCount: 2,
                     maxRetryDelay: TimeSpan.FromSeconds(5),
                     errorNumbersToAdd: null));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
