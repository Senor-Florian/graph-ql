using CrmGraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrmGraphQL.Persistence
{
    public class ModuleSettingRepository : Repository, IModuleSettingRepository
    {
        public ModuleSettingRepository(CrmDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<ModuleSetting> FindAsync()
        {
            return await dbContext.ModuleSettings.SingleOrDefaultAsync();
        }
    }
}
