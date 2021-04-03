using CrmGraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmGraphQL.Persistence
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(CrmDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<User>> ListAsync()
        {
            return await dbContext.User.ToListAsync();
        }
    }
}
