using it.example.dotnetcore5.domain.Interfaces.Models;
using it.example.dotnetcore5.domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IPost, Post>();
        }
    }
}