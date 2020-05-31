using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Posts.Commands;
using Blog.Domains.Posts.DTOs;
using Blog.Domains.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Blog.Services.Posts.Handler
{
    public class GetPostForListHandler:IRequestHandler<GetPostForListQuery,IEnumerable<PostListDTO>>
    {

        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;
        

        public GetPostForListHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;
            
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<PostListDTO>> Handle(GetPostForListQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetPostForList:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            return await _read.GetPostList();
        } 
        #endregion
    }
}
