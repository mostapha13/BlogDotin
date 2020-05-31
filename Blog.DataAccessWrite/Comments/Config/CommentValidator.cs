using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Comments;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Comments.Config
{
    public class CommentValidator : AbstractValidator<Comment>,IEntityTypeConfiguration<Comment>
    {
       
        public CommentValidator()
        {
            RuleFor(c => c.PostId).NotNull().WithName("پست");

            RuleFor(a => a.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(1500).WithMessage("حداکثر 1500 کاراکتر وارد نمایید")
                .WithName("متن");
 
        }

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasQueryFilter(c => !c.IsDelete);


            builder.HasOne(c => c.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
