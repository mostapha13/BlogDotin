using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Authors.Queries.GetAuthorById
{
   public class GetAuthorByIdQuery:IRequest<Author>
    {  
        public GetAuthorByIdQuery(long id)
        {
            Id = id;
        }
        public long Id { get; set; }
     

    }
}
