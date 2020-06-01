using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blog.DataAccessCommands.Authors.Config;
using Blog.DataAccessCommands.Comments.Config;
using Blog.DataAccessCommands.Posts.Config;
using Blog.DataAccessCommands.Subjects.Config;
using Blog.Domains.Authors;
using Blog.Domains.Base;
using Blog.Domains.Comments;
using Blog.Domains.Posts;
using Blog.Domains.Subjects;
using Microsoft.EntityFrameworkCore;


namespace Blog.DataAccessCommands.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Subject> Subjects { get; set; }






        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            #region Configuration

            modelBuilder.ApplyConfiguration(new AuthorConfig());

            modelBuilder.ApplyConfiguration(new SubjectConfig());

            modelBuilder.ApplyConfiguration(new PostConfig());

            modelBuilder.ApplyConfiguration(new CommentConfig());

            #endregion


            base.OnModelCreating(modelBuilder);
        }

        #endregion


        #region Save

        #region SaveChanges
        public override int SaveChanges()
        {
            CustomSaveChange();

            return base.SaveChanges();
        }

        #endregion

        #region SaveChanges

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            CustomSaveChange();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        #endregion

        #region SaveChangesAsync
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            CustomSaveChange();


            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region SaveChangesAsync

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            CustomSaveChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion


        #region CustomSaveChangeMethod

        private void CustomSaveChange()
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


        }

        #endregion

        #endregion
    }
}
