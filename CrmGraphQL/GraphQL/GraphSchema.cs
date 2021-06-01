using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class GraphSchema : Schema, ISchema
    {
        //public GraphSchema(IServiceProvider provider)
        //{
        //    Query = provider.GetRequiredService<RootQuery>();
        //}

        public GraphSchema(RootQuery query)
        {
            Query = query;
        }
    }
}
