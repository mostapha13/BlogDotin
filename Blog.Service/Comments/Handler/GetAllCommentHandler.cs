using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Comments;
using Blog.Domains.Comments.Commands;
using Blog.Domains.Comments.DTOs;
using Blog.Domains.Comments.Queries;
using MediatR;
using Serilog;

namespace Blog.Services.Comments.Handler
{
    public class GetAllCommentHandler : IRequestHandler<GetAllCommentQuery, IEnumerable<Comment>>
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

        public async Task<IEnumerable<Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAllComment:Get:";

            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

            return await _read.GetAllComment();



        } 
        #endregion
    }
}
