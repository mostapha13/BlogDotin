using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.CommentClasses.DTOs;
using FluentValidation;

namespace Blog.DataAccessCommand.CommentClasses.Config
{
    public class CommentDtoValidator : AbstractValidator<CommentDTO>
    {
        public CommentDtoValidator()
        {
            RuleFor(c => c.PostId).NotNull().WithMessage("پست را وارد نمایید").WithName("پست");

            RuleFor(a => a.Text).NotNull().WithMessage("متن را وارد نمایید")
                .MaximumLength(1500).WithMessage("حداکثر 1500 کاراکتر وارد نمایید")
                .WithName("متن");
        }


    }
}
