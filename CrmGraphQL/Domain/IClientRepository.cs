using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmGraphQL.Domain
{
    public interface IClientRepository
    {
        Task<List<Client>> ListAsync();
        Task<Client> FindAsync(Guid id);
    }
}
