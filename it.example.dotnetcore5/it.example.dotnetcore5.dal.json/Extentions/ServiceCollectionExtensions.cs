using it.example.dotnetcore5.dal.json.Repositories;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.dal.json.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDalJson(this IServiceCollection services)
        {
            services.AddScoped<IPostsRepository, PostsRepository>();
        }
    }
}