using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.CommentClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.CommentClasses.Config
{
   public class CommentValidator:IEntityTypeConfiguration<Comment>
    {

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.PostId).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(1500);

          

            
             
        }
    }
}
