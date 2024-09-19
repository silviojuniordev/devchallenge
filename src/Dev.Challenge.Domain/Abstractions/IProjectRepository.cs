using Dev.Challenge.Domain.Entities;
using System.Data.Common;

namespace Dev.Challenge.Domain.Abstractions
{
    public interface IProjectRepository : IRepository<Project>
    {
        void Add(Project project);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetById(Guid? id);
        DbConnection GetDbConnection();
    }
}
