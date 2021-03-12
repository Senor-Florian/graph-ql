using CrmGraphQL.Domain;
using CrmGraphQL.GraphQL;
using CrmGraphQL.Persistence;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
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
            services.AddSingleton<RootQuery>();
            services.AddSingleton<ClientQuery>();
            services.AddSingleton<ProjectQuery>();
            services.AddSingleton<GraphSchema>();
            services
                .AddGraphQL()
                .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<GraphSchema>();
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
