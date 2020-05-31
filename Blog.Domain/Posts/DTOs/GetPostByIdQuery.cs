using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Posts.DTOs
{
   public class GetPostByIdQuery:IRequest<Post>
    {
        public long Id { get; set; }

        public GetPostByIdQuery(long id)
        {
            Id = id;
        }
    }
}
