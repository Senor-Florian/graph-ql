using CrmGraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmGraphQL.Persistence
{
    public class ClientRepository : Repository, IClientRepository
    {
        public ClientRepository(CrmDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Client>> ListAsync()
        {
            return await dbContext.Client
                .Include(x => x.Projects)
                .Include(x => x.SalesRepresentative)
                .ToListAsync();
        }
    }
}
