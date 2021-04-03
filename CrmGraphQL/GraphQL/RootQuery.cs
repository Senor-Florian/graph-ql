using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(ClientQuery clientQuery, ProjectQuery projectQuery, UserQuery userQuery,  ModuleSettingQuery moduleSettingQuery)
        {
            AddField(clientQuery.GetClients());
            AddField(clientQuery.GetClienById());
            AddField(projectQuery.GetProjects());
            AddField(projectQuery.GetProjectById());
            AddField(userQuery.GetUsers());
            AddField(moduleSettingQuery.GetModuleSettings());
        }
    }
}
