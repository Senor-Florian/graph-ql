using CrmGraphQL.Domain;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmGraphQL.GraphQL
{
    public class ClientQuery : ObjectGraphType
    {
        private readonly IClientRepository _clientRepo;

        public ClientQuery(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }


        public FieldType GetClients()
        {
            return FieldAsync<ListGraphType<ClientType>>("clients",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IntGraphType> { Name = "year" }
                }),
                resolve: async context =>
                {
                    var data = await _clientRepo.ListAsync();

                    var createdYear = context.GetArgument<int?>("year");
                    if (createdYear.HasValue)
                    {
                        return data.Where(x => x.Created.Year == createdYear);
                    }

                    return data;
                });
        }

        public FieldType GetClienById()
        {
            return FieldAsync<ClientType>("client",
                arguments: new QueryArguments(new List<QueryArgument> {
                    new QueryArgument<GuidGraphType> { Name = "id" }
                }),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var data = await _clientRepo.FindAsync(id);
                    return data;
                });
        }
    }
}
