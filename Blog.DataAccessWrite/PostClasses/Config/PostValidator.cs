using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.PostClasses.Config
{
   public class PostValidator:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(250);
            builder.Property(p => p.SubjectId).IsRequired();
            builder.Property(p => p.Text).IsRequired();
            builder.Property(p => p.AuthoId).IsRequired();
        }
    }
}
