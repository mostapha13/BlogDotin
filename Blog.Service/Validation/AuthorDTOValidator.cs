using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses.DTOs;
using FluentValidation;

namespace Blog.Service.Validation
{
   public class AuthorDTOValidator:AbstractValidator<AuthorDTO>
    {
        public AuthorDTOValidator()
        {
            RuleFor(a=>a.FirstName).NotEmpty().MaximumLength(250);
            RuleFor(a => a.LastName).NotEmpty().MaximumLength(250);
            RuleFor(a => a.UserName).NotEmpty().MaximumLength(250);
            RuleFor(a => a.Email).NotEmpty().MaximumLength(500).EmailAddress();
        }
    }
}
