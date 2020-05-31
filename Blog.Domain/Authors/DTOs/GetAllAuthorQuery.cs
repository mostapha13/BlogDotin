using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace Blog.Domains.Authors.DTOs
{
   public class GetAllAuthorQuery:IRequest<IEnumerable<Author>>
    {
     
     
    }
}
