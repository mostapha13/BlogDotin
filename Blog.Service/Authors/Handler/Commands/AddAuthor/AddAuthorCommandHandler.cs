using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Commands.AddAuthor;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Enums;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Services.Authors.Handler.Commands.AddAuthor
{
    public class AddAuthorCommandHandler:IRequestHandler<AddAuthorCommand,ResultStatus>
    {

        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;



        public AddAuthorCommandHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion
        public async Task<ResultStatus> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {


            Author auth = new Author()
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                UserName = request.UserName.Trim().ToLower(),
                Email = request.Email.Trim().ToLower(),


            };
            await _write.AddAuthor(auth);
            await _write.Save();
            return ResultStatus.Success;

        }
    }
}