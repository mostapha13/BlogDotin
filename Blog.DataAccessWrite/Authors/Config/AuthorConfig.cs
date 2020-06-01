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
            builder.HasQueryFilter(a => !a.IsDelete);

            builder.HasMany(a => a.Posts)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthoId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
