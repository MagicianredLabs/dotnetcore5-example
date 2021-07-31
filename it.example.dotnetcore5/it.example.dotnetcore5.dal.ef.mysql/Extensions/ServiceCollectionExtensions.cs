using it.example.dotnetcore5.dal.ef.mysql.EfModels;
using it.example.dotnetcore5.dal.ef.mysql.Repositories;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.dal.ef.mysql.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDalMySql(this IServiceCollection services,
                string connectionString)
        {
            // Register SQL database configuration context as services.
            services.AddDbContext<MyblogContext>(
                options => {
                    options.UseMySQL(
                        connectionString
                        );
            });

            services.AddScoped<IPostsRepository, PostsRepository>();
        }
    }
}
