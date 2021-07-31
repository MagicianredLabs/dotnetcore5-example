using it.example.dotnetcore5.dal.dapper.Repositories;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.dal.dapper.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDalDapper(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

            services.AddScoped<IPostsRepository, PostsRepository>();
        }
    }
}