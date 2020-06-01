using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Comments;
using FluentValidation;

namespace Blog.Services.Comments.Validation
{
    public class CommentValidator : AbstractValidator<Comment>
    {

        public CommentValidator()
        {
            RuleFor(c => c.PostId).NotNull().WithName("پست");

            RuleFor(a => a.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(1500).WithMessage("حداکثر 1500 کاراکتر وارد نمایید")
                .WithName("متن");

        }


    }
}
