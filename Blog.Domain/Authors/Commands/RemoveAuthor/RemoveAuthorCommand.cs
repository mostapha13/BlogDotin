using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Authors.Commands.RemoveAuthor
{
   public class RemoveAuthorCommand:IRequest<ResultStatus>
    {  
        public RemoveAuthorCommand(long id)
        {
            Id = id;
        }
        public long Id { get; set; }
     
    }
}
