using System;
using System.Collections.Generic;
using System.Text;
using Blog.DataAccessCommand.AuthorClasses.Config;
using Blog.DataAccessCommand.CommentClasses.Config;
using Blog.DataAccessCommand.PostClasses.Config;
using Blog.DataAccessCommand.SubjectClasses.Config;
using Blog.Domain;
using Blog.Domain.AuthorClasses;
using Blog.Domain.CommentClasses;
using Blog.Domain.PostClasses;
using Blog.Domain.SubjectClasses;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccessCommand.Context
{
   public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            #region ValidatorAuthor

            modelBuilder.ApplyConfiguration(new AuthorValidator());

            #endregion

            #region ValidatorPost

            modelBuilder.ApplyConfiguration(new PostValidator());

            #endregion

            #region ValidatorSubject

            modelBuilder.ApplyConfiguration(new SubjectValidator());

            #endregion

            #region ValidatorComment
            modelBuilder.ApplyConfiguration(new CommentValidator()); 
            #endregion




            base.OnModelCreating(modelBuilder);
        }

        #endregion


    }
}
