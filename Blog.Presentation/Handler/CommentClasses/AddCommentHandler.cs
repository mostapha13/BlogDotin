using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Queries;
using Blog.Domain.Enum;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Handler.CommentClasses
{
    public class AddCommentHandler : IRequestHandler<CommentDTO, ResultStatus>
    {

        #region Constructor
        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;


        public AddCommentHandler(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion

        #region Handle

        public async Task<ResultStatus> Handle(CommentDTO request, CancellationToken cancellationToken)
        {
            string functionName = "AddComment:Post:" + JsonConvert.SerializeObject(request);



            Domain.CommentClasses.Comment comment = new Domain.CommentClasses.Comment()
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
