using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Service.AuthorClasses.Commands
{
   public class RemoveAuthorById:IRequest<ResultStatus>
    {
        public long Id { get; set; }

        public RemoveAuthorById(long id)
        {
            Id = id;
        }
    }
}
