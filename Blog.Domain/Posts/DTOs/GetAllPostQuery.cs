using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Posts.DTOs
{
   public class GetAllPostQuery:IRequest<IEnumerable<Post>>
    {
    }
}
