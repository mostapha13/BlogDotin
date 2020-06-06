using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Posts.Config
{
   public class PostConfig:IEntityTypeConfiguration<Post>
    {

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasQueryFilter(p => !p.IsDelete);

            builder.HasOne(p => p.Author)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);


            builder.HasOne(p => p.Subject)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.SubjectId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder.HasMany(p => p.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
