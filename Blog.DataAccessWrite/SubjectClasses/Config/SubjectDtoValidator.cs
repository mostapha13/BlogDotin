using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses.DTOs;
using FluentValidation;

namespace Blog.DataAccessCommand.SubjectClasses.Config
{
   public class SubjectDtoValidator:AbstractValidator<SubjectDTO>
    {
        public SubjectDtoValidator()
        {
           
            RuleFor(s => s.Title).NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان موضوع");
        }
    }
}
