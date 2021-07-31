using it.example.dotnetcore5.dal.fake.Repositories;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace it.example.dotnetcore5.dal.fake.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDalFake(this IServiceCollection services)
        {
            services.AddScoped<IPostsRepository, FakePostsRepository>();
        }
    }
}
