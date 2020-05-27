using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.SubjectClasses.Config
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(s => s.Id).NotNull();
            RuleFor(s => s.Title).NotNull().WithMessage("عنوان موضوع را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان موضوع");
        }
    }
}
