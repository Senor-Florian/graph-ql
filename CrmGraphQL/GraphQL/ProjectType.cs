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
        }
    }
}
