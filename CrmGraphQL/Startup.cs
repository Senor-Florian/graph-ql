using CrmGraphQL.Domain;
using CrmGraphQL.GraphQL;
using CrmGraphQL.Persistence;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrmGraphQL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // http://localhost:5201/ui/playground

            services.AddDbContext<CrmDbContext>(context => context.UseInMemoryDatabase("DB"));
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IModuleSettingRepository, ModuleSettingRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<RootQuery>();
            services.AddScoped<ClientQuery>();
            services.AddScoped<ProjectQuery>();
            services.AddScoped<UserQuery>();
            services.AddScoped<ModuleSettingQuery>();
            services.AddScoped<ISchema, GraphSchema>();
            services
                .AddGraphQL()
                .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<ISchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
