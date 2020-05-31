using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Comments;
using Blog.Domains.Comments.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Comments.Config
{
    public class CommentDtoValidator : AbstractValidator<CommentDTO>,IEntityTypeConfiguration<Comment>
    {
        
        public CommentDtoValidator()
        {
            RuleFor(c => c.PostId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید").WithName("پست");

            RuleFor(a => a.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(1500).WithMessage("حداکثر 1500 کاراکتر وارد نمایید")
                .WithName("متن");

          
        }


        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasQueryFilter(c => !c.IsDelete);

            
        }
    }
}
