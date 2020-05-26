﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using Blog.Service.PostClasses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Blog.Presentation.Handler.PostClasses
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
    }
}