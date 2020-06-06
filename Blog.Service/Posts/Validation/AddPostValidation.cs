using Blog.Domains.Posts.Commands.AddPost;
using FluentValidation;

namespace Blog.Services.Posts.Validation
{
    public class AddPostValidation:AbstractValidator<AddPostCommand>
    {
        public AddPostValidation()
        {

            RuleFor(p => p.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("حداکثر 250 کاراکتر وارد نمایید")
                .WithName("عنوان");

            RuleFor(p => p.SubjectId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("موضوع");

            RuleFor(p => p.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("متن");

            RuleFor(p => p.AuthorId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید").NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("نویسنده");


        }
    }
}