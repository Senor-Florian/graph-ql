using CrmGraphQL.Domain;
using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class ClientType : ObjectGraphType<Client>
    {
        public ClientType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Created);
            Field(x => x.SalesRepresentative, type: typeof(UserType));
            Field(x => x.Projects, type: typeof(ListGraphType<ProjectType>));
        }
    }
}
