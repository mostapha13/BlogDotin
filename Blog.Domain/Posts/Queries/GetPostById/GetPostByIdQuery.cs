﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<Post>
    {
        public GetPostByIdQuery(long id)
        {
            Id = id;
        }
        public long Id { get; set; }


    }
}
