using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Comments.Commands;
using Blog.Domains.Comments.DTOs;
using Blog.Domains.Comments.Queries;
using Blog.Domains.Comments.Queries.GetAllCommentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Blog.Services.Comments.Handler.query.GetAllCommentList
{
    public class GetAllCommentListQueryHandler:IRequestHandler<GetAllCommentListQuery,IEnumerable<CommentListDTO>>
    {

        #region Constructor
        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;
       

        public GetAllCommentListQueryHandler(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;
           
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<CommentListDTO>> Handle(GetAllCommentListQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAllCommentList:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            return await _read.GetAllCommentList();
        } 
        #endregion
    }
}
