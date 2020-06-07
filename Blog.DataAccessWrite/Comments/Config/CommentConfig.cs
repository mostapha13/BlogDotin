using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Comments.Config
{
   public class CommentConfig:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.Property(c => c.Text).IsRequired().HasMaxLength(1500);
            builder.Property(c => c.PostId).IsRequired();

            builder.HasQueryFilter(c => !c.IsDelete);
            builder.HasOne(c => c.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
