using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Posts;
using FluentValidation;

namespace Blog.Services.Posts.Validation
{

    public class PostValidator : AbstractValidator<Post>
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


    }
}
