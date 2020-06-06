using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Comments.DTOs;
using MediatR;

namespace Blog.Domains.Comments.Queries.GetAllCommentList
{
    public class GetAllCommentListQuery : IRequest<IEnumerable<CommentListDTO>>
    {
    }
}
