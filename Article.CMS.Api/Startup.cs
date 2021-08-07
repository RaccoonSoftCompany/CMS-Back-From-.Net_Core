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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Article.CMS.Api.Params;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using System.IO;
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
            // services.AddDbContext<ArticleCmsdb>(o => o.UseSqlServer());
            services.AddDbContext<ArticleCmsdb>(o => o.UseNpgsql());
            services.AddCors(m => m.AddPolicy("Any", a => a.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

            // 注入 IRepository接口及其实现类
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddControllers();

            //审计日志
            // services.AddControllers(options=>
            // {
            //     options.Filters.Add(typeof(AuditLogActionFilter));
            // });

            // 配置token验证的设置
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                var tokenParameter = Configuration.GetSection("TokenParameter").Get<TokenParameter>();
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenParameter.Secret)),
                    ValidateIssuer = true,
                    ValidIssuer = tokenParameter.Issuer,
                    ValidateAudience = false
                };

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

            #region 静态资源中间件 http://localhost:5000/uploadfiles/……
            // string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"UploadFiles");
            // if (!Directory.Exists(filepath))
            //     Directory.CreateDirectory(filepath);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"UploadFiles")),
                RequestPath = new Microsoft.AspNetCore.Http.PathString("/UploadFiles")
            }
            );

            #endregion

            //注册token的中间件
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("Any");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
