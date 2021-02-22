using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmGraphQL.Domain
{
    public interface IProjectRepository
    {
        Task<List<Project>> ListAsync();
    }
}
