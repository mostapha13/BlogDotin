using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses;
using MediatR;

namespace Blog.Service.PostClasses.Queries
{
   public class GetAllPostQuery:IRequest<IEnumerable<Post>>
    {
    }
}
