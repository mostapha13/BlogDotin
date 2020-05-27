using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.CommentClasses;
using MediatR;

namespace Blog.Domain.CommentClasses.DTOs
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
