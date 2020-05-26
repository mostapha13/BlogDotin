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
    public class GetAllCommentHandler:IRequestHandler<GetAllCommentQuery, IEnumerable<Comment>>
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
        public async Task<IEnumerable<Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAllComment:Get:";

            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);
           
                return await _read.GetAllComment();
            
      

    }
    }
}
