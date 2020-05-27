using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Domain.AuthorClasses.DTOs
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
