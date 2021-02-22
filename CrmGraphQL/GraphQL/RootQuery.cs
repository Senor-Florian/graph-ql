using CrmGraphQL.Domain;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace CrmGraphQL.GraphQL
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IClientRepository clientRepo, IProjectRepository projectRepo)
        {
            FieldAsync<ListGraphType<ClientType>>("clients",
                arguments: new QueryArguments(new List<QueryArgument> 
                {
                    new QueryArgument<IntGraphType> { Name = "year" }
                }),
                resolve: async context => {
                    var data = await clientRepo.ListAsync();

                    var createdYear = context.GetArgument<int?>("year");
                    if (createdYear.HasValue)
                    {
                        data = data.Where(x => x.Created.Year == createdYear).ToList();
                    }

                    return data;
                });

            FieldAsync<ListGraphType<ProjectType>>("projects",
                resolve: async context =>
                {
                    var data = await projectRepo.ListAsync();
                    return data;
                });
        }
    }
}
