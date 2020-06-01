using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Subjects;
using FluentValidation;

namespace Blog.Services.Subjects.Validation
{
   public class SubjectValidator:AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(s => s.Id).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull();

            RuleFor(s => s.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان موضوع");




        }

    }
}
