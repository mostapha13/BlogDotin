using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Authors.DTOs
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
