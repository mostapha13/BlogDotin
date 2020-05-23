using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.SubjectClasses.Config
{
   public class SubjectValidator:IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(250);
        }
    }
}
