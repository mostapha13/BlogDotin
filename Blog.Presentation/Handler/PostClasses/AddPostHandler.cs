using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Enum;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Handler.PostClasses
{
    public class AddPostHandler:IRequestHandler<PostDTO,ResultStatus>
    {
        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;
        

        public AddPostHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;
            
        }
        #endregion

        #region Handle

        public async Task<ResultStatus> Handle(PostDTO request, CancellationToken cancellationToken)
        {
            string functionName = "AddPost:Post:" + JsonConvert.SerializeObject(request);


            Domain.PostClasses.Post post = new Domain.PostClasses.Post()
            {
                Title = request.Title,
                AuthoId = long.Parse(request.AuthorId),
                SubjectId = long.Parse(request.SubjectId),
                Text = request.Text
            };

            await _write.AddPost(post);
            await _write.Save();
            return ResultStatus.Success;



        } 
        #endregion
    }
}
