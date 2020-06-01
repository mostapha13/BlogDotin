using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Authors;
using Blog.Domains.Authors.DTOs;
using FluentValidation;

namespace Blog.Services.Authors.Validation
{
    public class AuthorDtoValidator : AbstractValidator<AuthorDTO>
    {

        public AuthorDtoValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("{PropertyName} را وارد نمایید.").NotNull().WithMessage("{PropertyName} را وارد نمایید.")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید").WithName("نام");

            RuleFor(a => a.LastName).NotEmpty().WithMessage("{PropertyName} را وارد نمایید.").NotNull().WithMessage("{PropertyName} را وارد نمایید.")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید").WithName("نام خانوادگی");

            RuleFor(a => a.UserName).NotEmpty().WithMessage("{PropertyName} را وارد نمایید.").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید").WithName("نام کاربری");

            RuleFor(a => a.Email).NotEmpty().WithMessage("{PropertyName} را وارد نمایید.").NotNull()
                .WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر وارد نمایید").EmailAddress()
                .WithMessage("فرمت ایمیل وارد نمایید.").WithName("ایمیل");

        }


     
    }
}
