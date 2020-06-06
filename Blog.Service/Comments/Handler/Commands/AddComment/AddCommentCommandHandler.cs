using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Comments;
using Blog.Domains.Comments.Commands;
using Blog.Domains.Comments.Commands.AddComment;
using Blog.Domains.Comments.DTOs;
using Blog.Domains.Comments.Queries;
using Blog.Domains.Enums;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Services.Comments.Handler.Commands.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, ResultStatus>
    {

        #region Constructor

        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;


        public AddCommentCommandHandler(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion

        #region Handle

        public async Task<ResultStatus> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
           
            Comment comment = new Comment()
            {
                PostId = long.Parse(request.PostId),
                Text = request.Text
            };
            await _write.AddComment(comment);
            await _write.Save();
            return ResultStatus.Success;


        }


        #endregion
    }
}
