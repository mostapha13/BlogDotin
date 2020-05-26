using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.Queries;
using Blog.Domain.Enum;
using Blog.Service.AuthorClasses.Commands;
using Blog.Service.AuthorClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.AuthorClasses
{
    public class RemoveAuthorHandler : IRequestHandler<RemoveAuthorById, ResultStatus>
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
       


        public RemoveAuthorHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
          
        }
        #endregion
        public async Task<ResultStatus> Handle(RemoveAuthorById request, CancellationToken cancellationToken)
        {
            string functionName = "RemoveAuthor:Get:" + request.Id;

            var author = await _read.GetAuthorById(request.Id);
            if (author == null)
            {

                Log.ForContext("Message", functionName)
                    .ForContext("Error", "UserNotFound")
                    .Error($"Error: ** {functionName}");
                return ResultStatus.NotFound;
            }



            await _write.RemoveAuthor(author);
            await _write.Save();
            return ResultStatus.Success;


        }
    }
}
