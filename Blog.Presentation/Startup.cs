using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessCommand.AuthorClasses.Command;
using Blog.DataAccessRead.AuthorClasses.Query;
using Blog.DataAccessRead.CommentClasses.Query;
using Blog.DataAccessRead.PostClasses.Query;
using Blog.DataAccessRead.SubjectClasses.Query;
using Blog.DataAccessWrite.CommentClasses.Command;
using Blog.DataAccessWrite.PostClasses.Command;
using Blog.DataAccessWrite.SubjectClasses.Command;
using Blog.Domain.AuthorClasses.Command;
using Blog.Domain.AuthorClasses.Query;
using Blog.Domain.CommentClasses.Command;
using Blog.Domain.CommentClasses.Query;
using Blog.Domain.PostClasses.Command;
using Blog.Domain.PostClasses.Query;
using Blog.Domain.SubjectClasses.Command;
using Blog.Domain.SubjectClasses.Query;
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

            services.AddDbContext<Blog.DataAccessQuery.Context.BlogContext>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionStrings:QueryConnection"]);
                });


            services.AddDbContext<Blog.DataAccessCommand.Context.BlogContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:CommandConnection"]);
            });

            #endregion

            #region IOC

            #region Query

            services.AddScoped<IAuthorRepositoryQuery, AuthorRepositoryQuery>();
            services.AddScoped<ICommentRepositoryQuery, CommentRepositoryQuery>();
            services.AddScoped<IPostRepositoryQuery, PostRepositoryQuery>();
            services.AddScoped<ISubjectRepositoryQuery, SubjectRepositoryQuery>();

            #endregion


            #region Command

            services.AddScoped<IAuthorRepositoryCommand, AuthorRepositoryCommand>();
            services.AddScoped<ICommentRepositoryCommand, CommentRepositoryCommand>();
            services.AddScoped<IPostRepositoryCommand, PostRepositoryCommand>();
            services.AddScoped<ISubjectRepositoryCommand, SubjectRepositoryCommand>();


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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API", Version = "v1" });
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
            app.UseStaticFiles();

            #region Swagger
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog");
                // c.RoutePrefix = string.Empty;
            });


            #endregion

            app.UseRouting();

            app.UseCors("Blog");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
