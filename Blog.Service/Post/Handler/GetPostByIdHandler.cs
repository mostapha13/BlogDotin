using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.PostClasses
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
