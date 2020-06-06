using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Commands.AddAuthor;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Enums;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Services.PipelineBehaviors.Author
{
    public class AddAuthorBehavior<T, TR> : IPipelineBehavior<AddAuthorCommand, ResultStatus>

    {

        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;

        public AddAuthorBehavior(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }

        public async Task<ResultStatus> Handle(AddAuthorCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<ResultStatus> next)
        {

            

            if (await _read.IsEmailExist(request.Email.Trim().ToLower()))
            {
                Log.ForContext("Message", request)
                    .ForContext("Error", "EmailIsExist").Error($"Error: ** {request}");
                return ResultStatus.EmailExist;
            }



            if (await _read.IsUserNameExist(request.UserName.Trim().ToLower()))
            {
                Log.ForContext("Message", request)
                    .ForContext("Error", "UserNameIsExist")
                    .Error($"Error: ** {request}");
                return ResultStatus.UserNameExist;
            }

            return await next();
        }

    }
}