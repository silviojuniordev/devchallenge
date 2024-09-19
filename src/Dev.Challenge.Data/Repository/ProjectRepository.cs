using Dev.Challenge.Data.Context;
using Dev.Challenge.Domain.Abstractions;
using Dev.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Dev.Challenge.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Project project)
        {
            _context.Projects.Add(project);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            try
            {
                return await _context.Projects.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Project?> GetById(Guid? id)
        {
            return await _context.Projects.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public DbConnection GetDbConnection() => _context.Database.GetDbConnection();
    }
}
