using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(ClientQuery clientQuery, ProjectQuery projectQuery)
        {
            AddField(clientQuery.GetClients());
            AddField(clientQuery.GetClienById());
            AddField(projectQuery.GetProjects());
        }
    }
}
