using CrmGraphQL.Domain;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmGraphQL.GraphQL
{
    public class ProjectQuery : ObjectGraphType
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectQuery(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public FieldType GetProjects()
        {
            return FieldAsync<ListGraphType<ProjectType>>("projects",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<ListGraphType<GuidGraphType>> { Name = "salesRepresentatives" }
                }),
                resolve: async context =>
                {
                    var salesRepresentatives = context.GetArgument<List<Guid>>("salesRepresentatives") ?? new List<Guid>();
                    var data = await _projectRepo.ListAsync();
                    if (salesRepresentatives.Any())
                    {
                        return data.Where(x => salesRepresentatives.Contains(x.SalesRepresentativeId));
                    }
                    return data;
                });
        }

        public FieldType GetProjectById()
        {
            return FieldAsync<ProjectType>("project",
                arguments: new QueryArguments(new List<QueryArgument> {
                    new QueryArgument<GuidGraphType> { Name = "id" }
                }),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var data = await _projectRepo.FindAsync(id);
                    return data;
                });
        }
    }
}
