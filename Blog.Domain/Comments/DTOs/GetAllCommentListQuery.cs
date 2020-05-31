using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Comments.DTOs
{
   public class GetAllCommentListQuery:IRequest<IEnumerable<CommentListDTO>>
    {
    }
}
