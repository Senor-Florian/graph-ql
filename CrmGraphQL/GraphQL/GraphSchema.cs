using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace CrmGraphQL.GraphQL
{
    public class GraphSchema : Schema
    {
        public GraphSchema(IServiceProvider provider)
        {
            Query = provider.GetRequiredService<RootQuery>();
        }
    }
}
