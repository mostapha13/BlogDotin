using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Service.PostClasses.Commands
{
   public class RemovePostCommand:IRequest<ResultStatus>
    {
        public long Id { get; set; }

        public RemovePostCommand(long id)
        {
            Id = id;
        }
    }
}
