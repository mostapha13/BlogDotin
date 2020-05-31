using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Enums;
using Blog.Domains.Posts;
using Blog.Domains.Posts.Commands;
using Blog.Domains.Posts.DTOs;
using Blog.Domains.Posts.Queries;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Services.Posts.Handler
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
           
            Post post = new Post()
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
