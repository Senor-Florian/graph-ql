using CrmGraphQL.Domain;
using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class ProjectType : ObjectGraphType<Project>
    {
        public ProjectType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.ClientId);
            Field(x => x.SalesRepresentative, type: typeof(UserType));
            Field(x => x.InternalId);
            Field(x => x.ExternalId);
        }
    }
}
