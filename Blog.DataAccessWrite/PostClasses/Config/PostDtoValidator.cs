﻿using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses.DTOs;
using FluentValidation;

namespace Blog.DataAccessCommand.PostClasses.Config
{
    public class PostDtoValidator : AbstractValidator<PostDTO>
    {

        public PostDtoValidator()
        {
            RuleFor(p => p.Title).NotNull().WithMessage("عنوان را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان");

            RuleFor(p => p.SubjectId).NotNull().WithMessage("موضوع را وارد نمایید")
                .WithName("موضوع");

            RuleFor(p => p.Text).NotNull().WithMessage("متن را وارد نمایید")
                .WithName("متن");

            RuleFor(p => p.AuthorId).NotNull().WithMessage("نویسنده را وارد نمایید")
                .WithName("نویسنده");
        }


    }
}
