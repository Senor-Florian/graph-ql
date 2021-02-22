using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CrmGraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://*:5201")
                .Build();

            host.Run();
        }
    }
}
