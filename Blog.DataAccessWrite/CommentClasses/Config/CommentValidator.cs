using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.CommentClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.CommentClasses.Config
{
   public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.PostId).NotNull().WithName("پست");
           
            RuleFor(a => a.Text).NotNull().WithMessage("متن را وارد نمایید")
                .MaximumLength(1500).WithMessage("حداکثر 1500 کاراکتر وارد نمایید")
                .WithName("متن");
        }
    }
}
