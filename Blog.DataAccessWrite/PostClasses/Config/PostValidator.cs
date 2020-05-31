using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.PostClasses.Config
{
    public class PostValidator : AbstractValidator<Post>,IEntityTypeConfiguration<Post>
    {
    
        public PostValidator()
        {


            RuleFor(p => p.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان");

            RuleFor(p => p.SubjectId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
               .WithName("موضوع");

            RuleFor(p => p.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("متن");

            RuleFor(p => p.AuthoId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("نویسنده");

           

        }


        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasQueryFilter(p => !p.IsDelete);

            builder.HasOne(p => p.Author)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.AuthoId)
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
