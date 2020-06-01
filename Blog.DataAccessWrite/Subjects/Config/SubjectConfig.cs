using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Subjects.Config
{

    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasQueryFilter(s => !s.IsDelete);

            builder.HasMany(s => s.Posts)
                .WithOne(s => s.Subject)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
