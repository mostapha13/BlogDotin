using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Queries;
using Blog.Service.CommentClasses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Blog.Presentation.Handler.CommentClasses
{
    public class GetAllCommentListHandler:IRequestHandler<GetAllCommentListQuery,IEnumerable<CommentListDTO>>
    {

        #region Constructor
        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;
       

        public GetAllCommentListHandler(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;
           
        }
        #endregion


        public async Task<IEnumerable<CommentListDTO>> Handle(GetAllCommentListQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAllCommentList:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            return await _read.GetAllCommentList();
        }
    }
}
