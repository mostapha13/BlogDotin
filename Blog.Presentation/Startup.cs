using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Blog.DataAccessCommands.Context;
using Blog.DataAccessCommands.Authors.Repository;
using Blog.DataAccessCommands.Comments.Repository;
using Blog.DataAccessCommands.Posts.Repository;
using Blog.DataAccessCommands.Subjects.Repository;
using Blog.DataAccessQueries.Authors.Repository;
using Blog.DataAccessQueries.Comments.Repository;
using Blog.DataAccessQueries.Posts.Repository;
using Blog.DataAccessQueries.Subjects.Repository;
using Blog.Domains.Authors;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.DTOs;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Comments;
using Blog.Domains.Comments.Commands;
using Blog.Domains.Comments.DTOs;
using Blog.Domains.Comments.Queries;
using Blog.Domains.Posts;
using Blog.Domains.Posts.Commands;
using Blog.Domains.Posts.DTOs;
using Blog.Domains.Posts.Queries;
using Blog.Domains.Subjects;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries;
using Blog.Presentation.Middleware;
using Blog.Services.Authors.Validation;
using Blog.Services.Comments.Validation;
using Blog.Services.PipelineBehaviors;
using Blog.Services.Posts.Validation;
using Blog.Services.Subjects.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
using Serilog;

namespace Blog.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            #region SeriLog

            Log.Logger = new LoggerConfiguration()

               .ReadFrom.Configuration(Configuration)
               .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();
            #endregion

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region MediatR

            var assembly = AppDomain.CurrentDomain.Load("Blog.Services");
            services.AddMediatR(assembly);

            #endregion

            #region Validation

            services.AddMvc().AddFluentValidation();
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
           

             services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            services.AddTransient<IValidator<Author>, AuthorValidator>();
            services.AddTransient<IValidator<AuthorDTO>, AuthorDtoValidator>();

            services.AddTransient<IValidator<Post>, PostValidator>();
            services.AddTransient<IValidator<PostDTO>, PostDtoValidator>();


            services.AddTransient<IValidator<Comment>, CommentValidator>();
            services.AddTransient<IValidator<CommentDTO>, CommentDtoValidator>();


            services.AddTransient<IValidator<Subject>, SubjectValidator>();
            services.AddTransient<IValidator<SubjectDTO>, SubjectDtoValidator>();



            #endregion

            services.AddControllers();

            #region DBContext


            services.AddDbContext<BlogContext>(options =>
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDirectoryBrowser();
                app.UseDeveloperExceptionPage();

            }
            
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            #region SeriLog

            loggerFactory.AddSerilog();

            #endregion

            #region Swagger
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog");
               
            });


            #endregion


            app.UseRouting();

            #region Cors
            app.UseCors("Blog");
            #endregion


            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorHandling));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
