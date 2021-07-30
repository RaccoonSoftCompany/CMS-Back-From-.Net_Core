using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Article.CMS.Api.Database;
using Microsoft.EntityFrameworkCore;
using Article.CMS.Api.Repository;
using Article.CMS.Api.Filters;
//using Article.CMS.Api.Repository;

namespace Article.CMS.Api
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

            // 注入数据库上下文
            services.AddDbContext<ArticleCmsdb>(o => o.UseSqlServer());
            services.AddCors(m => m.AddPolicy("Any", a => a.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

            // 注入 IRepository接口及其实现类
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddControllers();
        
            services.AddControllers(options=>
            {
                options.Filters.Add(typeof(AuditLogActionFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Article.CMS.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors("Any");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
