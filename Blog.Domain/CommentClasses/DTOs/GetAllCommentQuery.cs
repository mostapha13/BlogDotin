using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.CommentClasses;
using MediatR;

namespace Blog.Domain.CommentClasses.DTOs
{
   public class GetAllCommentQuery:IRequest<IEnumerable<Comment>>
    {
    }
}
