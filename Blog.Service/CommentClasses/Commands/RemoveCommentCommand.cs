using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Service.CommentClasses.Commands
{
   public class RemoveCommentCommand:IRequest<ResultStatus>
    {
        public long Id { get; set; }

        public RemoveCommentCommand(long id)
        {
            Id = id;
        }
    }
}
