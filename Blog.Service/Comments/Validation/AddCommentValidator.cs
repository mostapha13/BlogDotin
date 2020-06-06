using Blog.Domains.Comments.Commands.AddComment;
using FluentValidation;

namespace Blog.Services.Comments.Validation
{
    public class AddCommentValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentValidator()
        {
            RuleFor(c => c.PostId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید").WithName("پست");

            RuleFor(a => a.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(1500).WithMessage("حداکثر 1500 کاراکتر وارد نمایید")
                .WithName("متن");
        }
    }
}