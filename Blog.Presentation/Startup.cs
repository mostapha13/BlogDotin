using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessCommand.AuthorClasses.Config;
using Blog.DataAccessCommand.AuthorClasses.Repository;
using Blog.DataAccessCommand.CommentClasses.Repository;
using Blog.DataAccessCommand.PostClasses.Repository;
using Blog.DataAccessCommand.SubjectClasses.Repository;
using Blog.DataAccessQuery.AuthorClasses.Repository;
using Blog.DataAccessQuery.CommentClasses.Repository;
using Blog.DataAccessQuery.PostClasses.Repository;
using Blog.DataAccessQuery.SubjectClasses.Repository;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.Queries;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.Queries;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.Queries;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
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
            services.AddControllers();

            #region DBContext


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
