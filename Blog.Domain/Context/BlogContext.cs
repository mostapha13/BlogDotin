using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses;
using Blog.Domain.CommentClasses;
using Blog.Domain.PostClasses;
using Blog.Domain.SubjectClasses;
using Microsoft.EntityFrameworkCore;

namespace Blog.Domain.Context
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
            base.OnModelCreating(modelBuilder);
        }

        #endregion


    }
}
