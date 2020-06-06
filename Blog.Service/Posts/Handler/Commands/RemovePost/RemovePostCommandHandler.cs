using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Enums;
using Blog.Domains.Posts.Commands;
using Blog.Domains.Posts.Commands.RemovePost;
using Blog.Domains.Posts.Queries;
using MediatR;
using Serilog;

namespace Blog.Services.Posts.Handler.Commands.RemovePost
{
    public class RemovePostCommandHandler : IRequestHandler<RemovePostCommand, ResultStatus>
    {

        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;


        public RemovePostCommandHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion

        #region Handle

        public async Task<ResultStatus> Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {

            string functionName = "RemovePost:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            var post = await _read.GetPostById(request.Id);
            if (post == null)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "PostNotFound")
                    .Error($"Error: ** {functionName}");
                return ResultStatus.NotFound;
            }


            await _write.RemovePost(post);
            await _write.Save();
            return ResultStatus.Success;




        } 
        #endregion
    }
}
