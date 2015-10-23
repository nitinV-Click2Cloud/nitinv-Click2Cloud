using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;
namespace UsingOptions
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public IConfiguration Configuration { get; set; }
        public Startup(IApplicationEnvironment appEnv)
        {
            var configBuilder = new Microsoft.Framework.Configuration.ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json");
            Configuration = configBuilder.Build();
            var connString = Configuration.Get("Data:DefaultConnection:ConnectionString");

        }
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync( "Hello World!Connection STring FOr This "+ Configuration.Get("Data:DefaultConnection:ConnectionString"));
            });
        }
    }
}
