using System.Threading.Tasks;

namespace CrmGraphQL.Domain
{
    public interface IModuleSettingRepository
    {
        Task<ModuleSetting> FindAsync();
    }
}
