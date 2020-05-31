using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Posts;
using Blog.Domains.Posts.Commands;
using Blog.Domains.Posts.DTOs;
using Blog.Domains.Posts.Queries;
using MediatR;
using Serilog;

namespace Blog.Services.Posts.Handler
{
    public class GetPostByIdHandler:IRequestHandler<GetPostByIdQuery,Post>
    {

        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;
        

        public GetPostByIdHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;
           
        }
        #endregion

        #region Handle

        public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {

            string functionName = "GetPostById:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

            return await _read.GetPostById(request.Id);

        } 
        #endregion
    }
}
