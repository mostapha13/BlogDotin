using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Authors.Config
{
   public class AuthorConfig: IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
           
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(250);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(250);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(500);
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(250);


            builder.HasQueryFilter(a => !a.IsDelete);
            builder.HasMany(a => a.Posts)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
