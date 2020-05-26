using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.CommentClasses.DTOs;
using MediatR;

namespace Blog.Service.CommentClasses.Queries
{
   public class GetAllCommentListQuery:IRequest<IEnumerable<CommentListDTO>>
    {
    }
}
