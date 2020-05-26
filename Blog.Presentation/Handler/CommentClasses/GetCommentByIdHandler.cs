using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.Queries;
using Blog.Service.CommentClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.CommentClasses
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {

        #region Constructor
        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;
      

        public GetCommentByIdHandler(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;
         
        }
        #endregion

        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetCommentById:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);
            
                return  await _read.GetCommentById(request.Id);
          
        }
    }
}
