using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Commands.RemoveAuthor;
using Blog.Domains.Authors.DTOs;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Enums;
using MediatR;
using Serilog;

namespace Blog.Services.Authors.Handler.Commands.RemoveAuthor
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, ResultStatus>
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
       


        public RemoveAuthorCommandHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
          
        }
        #endregion

        #region 

        public async Task<ResultStatus> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
           

            var author = await _read.GetAuthorById(request.Id);
            if (author == null)
            {

                Log.ForContext("Message", "RemoveAuthor:Get:" + request.Id)
                    .ForContext("Error", "UserNotFound")
                    .Error($"Error: ** RemoveAuthor: Get: {request.Id}");
                return ResultStatus.NotFound;
            }



            await _write.RemoveAuthor(author);
            await _write.Save();
            return ResultStatus.Success;


        }


        #endregion
    }
}
