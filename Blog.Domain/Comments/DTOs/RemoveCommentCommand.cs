using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Comments.DTOs
{
    public class RemoveCommentCommand : IRequest<ResultStatus>
    {
        public RemoveCommentCommand(long id)
        {
            Id = id;
        }
        public long Id { get; set; }


    }
}
