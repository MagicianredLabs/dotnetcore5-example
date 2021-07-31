using it.example.dotnetcore5.bl.Services;
using it.example.dotnetcore5.domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.bl.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBL(this IServiceCollection services)
        {
            services.AddScoped<IPostsService, PostsService>();
        }
    }
}
