﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Comments.DTOs
{
    public class GetCommentByIdQuery : IRequest<Comment>
    {
        public GetCommentByIdQuery(long id)
        {
            Id = id;
        }
        public long Id { get; set; }


    }
}
