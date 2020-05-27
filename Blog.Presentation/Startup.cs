using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Blog.DataAccessCommand.AuthorClasses.Config;
using Blog.DataAccessCommand.AuthorClasses.Repository;
using Blog.DataAccessCommand.CommentClasses.Config;
using Blog.DataAccessCommand.CommentClasses.Repository;
using Blog.DataAccessCommand.PostClasses.Config;
using Blog.DataAccessCommand.PostClasses.Repository;
using Blog.DataAccessCommand.SubjectClasses.Config;
using Blog.DataAccessCommand.SubjectClasses.Repository;
using Blog.DataAccessQuery.AuthorClasses.Repository;
using Blog.DataAccessQuery.CommentClasses.Repository;
using Blog.DataAccessQuery.PostClasses.Repository;
using Blog.DataAccessQuery.SubjectClasses.Repository;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.DTOs;
using Blog.Domain.AuthorClasses.Queries;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Queries;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.DTOs;
using Blog.Domain.SubjectClasses.Queries;
using Blog.Service.PipelineBehaviors;
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

            var assembly = AppDomain.CurrentDomain.Load("Blog.Service");
            services.AddMediatR(assembly);


            #endregion

            #region Validation
            services.AddMvc().AddFluentValidation();
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
           // services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            services.AddValidatorsFromAssembly(assembly);

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

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
                // c.RoutePrefix = string.Empty;
            });


            #endregion


            app.UseRouting();

            #region Cors
            app.UseCors("Blog");
            #endregion


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
