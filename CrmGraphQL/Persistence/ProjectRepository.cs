using CrmGraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmGraphQL.Persistence
{
    public class ProjectRepository : Repository, IProjectRepository
    {
        public ProjectRepository(CrmDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Project>> ListAsync()
        {
            return await dbContext.Project
                .Include(x => x.SalesRepresentative)
                .ToListAsync();
        }
    }
}
