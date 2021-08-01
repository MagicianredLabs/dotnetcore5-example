using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using it.example.dotnetcore5.domain.Interfaces.Models;
using it.example.dotnetcore5.domain.Models;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using it.example.dotnetcore5.domain.Interfaces.Services;
using it.example.dotnetcore5.dal.fake.Repositories;
using it.example.dotnetcore5.bl.Services;

namespace it.example.dotnetcore5.webapi.tests.integration.Controllers.Helpers
{
    public static class CreateHostBuilderTestHelper
    {
        public static IHostBuilder GetHostBuilderTest()
        {
            return new HostBuilder()
                    //.ConfigureAppConfiguration((hostContext, configApp) =>
                    //{
                    //    configApp.AddJsonFile("testsettings.json", optional: false);
                    //})
                    .ConfigureWebHost(webHost =>
                    {
                        webHost.UseTestServer();
                        webHost.ConfigureServices((hostContext, services) =>
                        {
                        });
                        webHost.UseStartup<Startup>();
                    });
        }
    }
}
