using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Posts;
using Blog.Domains.Posts.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Posts.Config
{
    public class PostDtoValidator : AbstractValidator<PostDTO>,IEntityTypeConfiguration<Post>
    {

        
        public PostDtoValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان");

            RuleFor(p => p.SubjectId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("موضوع");

            RuleFor(p => p.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("متن");

            RuleFor(p => p.AuthorId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("نویسنده");

          
        }


        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasQueryFilter(p => !p.IsDelete);
        }
    }
}
