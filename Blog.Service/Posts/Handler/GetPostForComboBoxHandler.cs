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
    public class GetPostForComboBoxHandler:IRequestHandler<GetPostForComboBoxQuery,IEnumerable<PostForComboboxDTO>>
    {

        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;
       

        public GetPostForComboBoxHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;
            
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<PostForComboboxDTO>> Handle(GetPostForComboBoxQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetPostForComboBox:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            List<PostForComboboxDTO> listPost = new List<PostForComboboxDTO>();
            var posts = await _read.GetAllPost();

            foreach (var post in posts)
            {
                listPost.Add(new PostForComboboxDTO()
                {
                    Id = post.Id,
                    Post = post.Title
                });
            }

            return listPost;
        } 
        #endregion
    }
}
