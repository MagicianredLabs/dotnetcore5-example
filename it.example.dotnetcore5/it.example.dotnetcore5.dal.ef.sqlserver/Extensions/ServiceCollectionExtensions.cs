using it.example.dotnetcore5.dal.ef.sqlserver.EfModels;
using it.example.dotnetcore5.dal.ef.sqlserver.Repositories;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.dal.ef.sqlserver.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDalSqlServer(this IServiceCollection services,
                string connectionString)
        {
            // Register SQL database configuration context as services.
            services.AddDbContext<MyBlog_02Context>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IPostsRepository, PostsRepository>();
        }
    }
}