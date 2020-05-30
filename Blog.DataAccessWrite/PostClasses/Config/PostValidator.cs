﻿using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.PostClasses.Config
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {


            RuleFor(p => p.Title).NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان");

            RuleFor(p => p.SubjectId).NotNull().WithMessage("{PropertyName} را وارد نمایید")
               .WithName("موضوع");

            RuleFor(p => p.Text).NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("متن");

            RuleFor(p => p.AuthoId).NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("نویسنده");

        }




    }
}
