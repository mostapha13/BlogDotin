using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses;
using MediatR;

namespace Blog.Domain.AuthorClasses.DTOs
{
   public class GetAuthorByIdQuery:IRequest<Author>
    {
        public long Id { get; set; }

        public GetAuthorByIdQuery(long id)
        {
            Id = id;
        }

    }
}
