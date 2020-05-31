using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Comments.DTOs
{
   public class GetCommentByIdQuery:IRequest<Comment>
    {
        public long Id { get; set; }

        public GetCommentByIdQuery(long id)
        {
            Id = id;
        }
    }
}
