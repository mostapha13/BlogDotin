using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Comments.Commands;
using Blog.Domains.Comments.DTOs;
using Blog.Domains.Comments.Queries;
using Blog.Domains.Enums;
using MediatR;
using Serilog;

namespace Blog.Services.Comments.Handler
{
    public class RemoveCommentHandler : IRequestHandler<RemoveCommentCommand, ResultStatus>
    {
        #region Constructor
        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;


        public RemoveCommentHandler(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion

        #region Handle

        public async Task<ResultStatus> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {

            string functionName = "RemoveComment:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            var comment = await _read.GetCommentById(request.Id);
            if (comment == null)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "CommentNotFound")
                    .Error($"Error: ** {functionName}");
                return ResultStatus.NotFound;
            }

            await _write.RemoveComment(comment);
            await _write.Save();
            return ResultStatus.Success;

        } 
        #endregion
    }
}
