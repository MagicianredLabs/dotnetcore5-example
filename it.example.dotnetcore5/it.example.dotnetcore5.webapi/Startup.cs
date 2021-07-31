using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

// for Domain layer
using it.example.dotnetcore5.domain.Extensions;

// for BL layer
using it.example.dotnetcore5.bl.Extensions;

// for fake repository
//using it.example.dotnetcore5.dal.json.Extentions;

// for dapper
//using it.example.dotnetcore5.dal.dapper.Extentions;

// for json file
// using it.example.dotnetcore5.dal.json.Repositories;

// for ef sql server repository
// using it.example.dotnetcore5.dal.ef.sqlserver.Extensions;

// for ef mysql repository
//using it.example.dotnetcore5.dal.ef.mysql.Extensions;

// for ef sqlite repository
using it.example.dotnetcore5.dal.ef.sqlite.Extensions;

namespace it.example.dotnetcore5.webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "it.example.dotnetcore5.webapi", Version = "v1" });
            });

            services.AddDomain();

            // add fake dal
            //services.AddDalFake();

            // add dapper dal
            //services.AddDalDapper();

            // add json dal
            //services.AddDalJson();

            // add mysql dal
            //services.AddDalMySql(Configuration.GetConnectionString("myBlog_mysql"));

            // add sqlite dal
            services.AddDalSqlite(Configuration.GetConnectionString("myBlog_sqlite"));

            // Configuration for Sql Server
            //services.AddDalSqlServer(Configuration.GetConnectionString("myBlog_mssql"));

            // add BL layer
            services.AddBL();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "it.example.dotnetcore5.webapi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
