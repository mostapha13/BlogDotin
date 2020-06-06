using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Posts;
using Blog.Domains.Posts.Commands;
using Blog.Domains.Posts.Queries;
using Blog.Domains.Posts.Queries.GetAllPost;
using MediatR;
using Serilog;

namespace Blog.Services.Posts.Handler.Queries.GetAllPost
{
    public class GetAllPostQueryHandler:IRequestHandler<GetAllPostQuery,IEnumerable<Post>>
    {
        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;

        public GetAllPostQueryHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<Post>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {

            string functionName = "GetAllPost:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);



            return await _read.GetAllPost();

        } 
        #endregion
    }
}
