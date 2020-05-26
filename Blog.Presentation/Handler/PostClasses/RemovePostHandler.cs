using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Enum;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.Queries;
using Blog.Service.PostClasses.Commands;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.PostClasses
{
    public class RemovePostHandler : IRequestHandler<RemovePostCommand, ResultStatus>
    {

        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;


        public RemovePostHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion

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
    }
}
