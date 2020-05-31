using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Authors.DTOs
{
   public class RemoveAuthorCommand:IRequest<ResultStatus>
    {
        public long Id { get; set; }

        public RemoveAuthorCommand(long id)
        {
            Id = id;
        }
    }
}
