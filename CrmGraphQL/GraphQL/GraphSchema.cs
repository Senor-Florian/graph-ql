using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace CrmGraphQL.GraphQL
{
    public class GraphSchema : Schema
    {
        //public GraphSchema(IServiceProvider provider)
        //{
        //    Query = provider.GetRequiredService<RootQuery>();
        //}

        //There is one, and only one endpoint in GraphQL.This endpoint exposes a schema that is used to let the API consumer know the 
        //functionality available for the clients to consume, i.e., what data they can expect and the actions they can perform.
        //A Schema in GraphQL is represented by a class that extends the Schema class pertaining to the GraphQL.Types namespace.

        public GraphSchema(RootQuery query)
        {
            Query = query;
        }
    }
}
