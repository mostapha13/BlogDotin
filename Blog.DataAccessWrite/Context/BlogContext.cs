using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blog.DataAccessCommand.AuthorClasses.Config;
using Blog.DataAccessCommand.CommentClasses.Config;
using Blog.DataAccessCommand.PostClasses.Config;
using Blog.DataAccessCommand.SubjectClasses.Config;
using Blog.Domain;
using Blog.Domain.AuthorClasses;
using Blog.Domain.BaseEntityClasses;
using Blog.Domain.CommentClasses;
using Blog.Domain.LogClasses;
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

        public DbSet<Log> Log { get; set; }
            

        

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region QueryFilterIsDelete

            modelBuilder.Entity<Author>().HasQueryFilter(a => !a.IsDelete);
            modelBuilder.Entity<Subject>().HasQueryFilter(s => !s.IsDelete);
            modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDelete);
            modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDelete);

            #endregion


           

         //   base.OnModelCreating(modelBuilder);
        }

        #endregion


        #region SaveChanges
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                                e.State == EntityState.Added
                                || e.State == EntityState.Modified));



            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }




            return base.SaveChanges();
        }

        #endregion

        #region SaveChangesAsync
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {



            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                                e.State == EntityState.Added
                                || e.State == EntityState.Modified));



            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }



            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion


    }
}
