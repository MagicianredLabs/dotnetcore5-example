using it.example.dotnetcore5.dal.ef.sqlite.EfModels;
using it.example.dotnetcore5.dal.ef.sqlite.Repositories;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.dal.ef.sqlite.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDalSqlite(this IServiceCollection services,
                string connectionString)
        {
            // Register SQL database configuration context as services.
            services.AddDbContext<BlogContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IPostsRepository, PostsRepository>();
        }
    }
}