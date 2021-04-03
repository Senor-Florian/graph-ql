using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmGraphQL.Domain
{
    public interface IUserRepository
    {
        Task<List<User>> ListAsync();
    }
}
