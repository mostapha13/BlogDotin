using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Subjects.DTOs;
using FluentValidation;

namespace Blog.Services.Subjects.Validation
{
  public  class SubjectDtoValidator:AbstractValidator<SubjectDTO>
    {
        public SubjectDtoValidator()
        {

            RuleFor(s => s.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان موضوع");


        }


    }
}
