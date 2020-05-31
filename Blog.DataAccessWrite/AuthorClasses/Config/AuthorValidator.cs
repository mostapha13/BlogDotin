using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.AuthorClasses.Config
{

    public class AuthorValidator : AbstractValidator<Author>,IEntityTypeConfiguration<Author>
    {
        
        public AuthorValidator()
        {
            

            RuleFor(a => a.FirstName).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید.")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید").WithName("نام");

            RuleFor(a => a.LastName).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید.")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("نام خانوادگی");

            RuleFor(a => a.UserName).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("نام کاربری");

            RuleFor(a => a.Email).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر وارد نمایید")
                .EmailAddress().WithMessage("فرمت ایمیل وارد نمایید.").WithName("ایمیل");
            
               
        }


        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasQueryFilter(a => !a.IsDelete);

            builder.HasMany(a => a.Posts)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthoId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }

}


