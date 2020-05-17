using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessRead.Implementation;
using Blog.DataAccessWrite.Implementation;
using Blog.Domain.Context;
using Blog.Service.Read;
using Blog.Service.Write;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Blog.Presentation
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


            #region DBContext

            services.AddDbContext<BlogContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            #endregion

            #region IOC

            #region Read

            services.AddScoped<IAuthorRepositoryRead, AuthorRepositoryRead>();
            services.AddScoped<ICommentRepositoryRead, CommentRepositoryRead>();
            services.AddScoped<IPostRepositoryRead, PostRepositoryRead>();
            services.AddScoped<ISubjectRepositoryRead, SubjectRepositoryRead>();

            #endregion


            #region Write

            services.AddScoped<IAuthorRepositoryWrite, AuthorRepositoryWrite>();
            services.AddScoped<ICommentRepositoryWrite, CommentRepositoryWrite>();
            services.AddScoped<IPostRepositoryWrite, PostRepositoryWrite>();
            services.AddScoped<ISubjectRepositoryWrite, SubjectRepositoryWrite>();


            #endregion


            #endregion

            #region CORS

            services.AddCors(options =>
            {
                options.AddPolicy("Blog", buider =>
                    {
                        buider
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .Build();
                    });
            });

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

           

            app.UseRouting();

            app.UseCors("Blog");
 #region Swagger
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            }); 
            #endregion
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
