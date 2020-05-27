using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses;
using MediatR;

namespace Blog.Domain.PostClasses.DTOs
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
