using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Posts;
using Blog.Domains.Posts.Commands;
using Blog.Domains.Posts.Queries;
using Blog.Domains.Posts.Queries.GetPostBySubjectId;
using MediatR;
using Serilog;

namespace Blog.Services.Posts.Handler.Queries.GetPostBySubjectId
{
    public class GetPostBySubjectIdQueryHandler:IRequestHandler<GetPostBySubjectIdQuery,IEnumerable<Post>>
    {

        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;
        

        public GetPostBySubjectIdQueryHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;
           
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<Post>> Handle(GetPostBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetPostBySubjectId:Get:" + request.SubjectId;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);


            return await _read.GetPostBySubjectId(request.SubjectId);

        } 
        #endregion
    }
}
