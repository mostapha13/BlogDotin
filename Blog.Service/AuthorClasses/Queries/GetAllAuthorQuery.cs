using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses;
using MediatR;
using Serilog;

namespace Blog.Service.AuthorClasses.Queries
{
   public class GetAllAuthorQuery:IRequest<IEnumerable<Author>>
    {
     
    }
}
