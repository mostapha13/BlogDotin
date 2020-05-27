using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.AuthorClasses.Config
{

    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FirstName).NotNull().WithMessage("نام را وارد نمایید.")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید").WithName("نام");

            RuleFor(a => a.LastName).NotNull().WithMessage("نام خانوادگی را وارد نمایید.")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("نام خانوادگی");

            RuleFor(a => a.UserName).NotNull().WithMessage("نام کاربری را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("نام کاربری");

            RuleFor(a => a.Email).NotNull().WithMessage("ایمیل را وارد نمایید")
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر وارد نمایید")
                .EmailAddress().WithMessage("فرمت ایمیل وارد نمایید.").WithName("ایمیل");

        }
    }

}


