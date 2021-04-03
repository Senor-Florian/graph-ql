using CrmGraphQL.Domain;
using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class ModuleSettingType : ObjectGraphType<ModuleSetting>
    {
        public ModuleSettingType()
        {
            Field(x => x.ShowProjectInternalId);
            Field(x => x.CanSalesRepresentativeEditProjectExternalId);
        }
    }
}
