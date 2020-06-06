using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Comments.DTOs
{
    public class GetAllCommentQuery : IRequest<IEnumerable<Comment>>
    {
    }
}
