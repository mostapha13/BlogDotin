using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Comments.Queries.GetAllComment
{
    public class GetAllCommentQuery : IRequest<IEnumerable<Comment>>
    {
    }
}
