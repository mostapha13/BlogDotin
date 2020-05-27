using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Service.Comment.Handler
{
    public class GetAllCommentHandler : IRequestHandler<GetAllCommentQuery, IEnumerable<Domain.CommentClasses.Comment>>
    {
        #region Constructor
        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;


        public GetAllCommentHandler(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion

        #region Handle

        public async Task<IEnumerable<Domain.CommentClasses.Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAllComment:Get:";

            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

            return await _read.GetAllComment();



        } 
        #endregion
    }
}
