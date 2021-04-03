using CrmGraphQL.Domain;
using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class ModuleSettingQuery : ObjectGraphType
    {
        private readonly IModuleSettingRepository _moduleSettingRepo;

        public ModuleSettingQuery(IModuleSettingRepository moduleSettingRepo)
        {
            _moduleSettingRepo = moduleSettingRepo;
        }

        public FieldType GetModuleSettings()
        {
            return FieldAsync<ModuleSettingType>("moduleSettings", 
                resolve: async _ =>
                {
                    return await _moduleSettingRepo.FindAsync();
                });
        }
    }
}
