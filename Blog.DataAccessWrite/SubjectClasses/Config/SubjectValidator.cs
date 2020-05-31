using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.SubjectClasses.Config
{
    public class SubjectValidator : AbstractValidator<Subject>,IEntityTypeConfiguration<Subject>
    {
        
        public SubjectValidator()
        {
            RuleFor(s => s.Id).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull();

            RuleFor(s => s.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان موضوع");

        

         
        }


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
