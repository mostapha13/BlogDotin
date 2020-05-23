using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.AuthorClasses.Config
{

    public class AuthorValidator : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(250);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(250);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(250);
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(250);
            


        }
    }


}


