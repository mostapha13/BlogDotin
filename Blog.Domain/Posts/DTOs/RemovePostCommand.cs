using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Posts.DTOs
{
    public class RemovePostCommand : IRequest<ResultStatus>
    {
        public RemovePostCommand(long id)
        {
            Id = id;
        }
        public long Id { get; set; }


    }
}
