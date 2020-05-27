using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses;
using MediatR;
using Serilog;

namespace Blog.Domain.AuthorClasses.DTOs
{
   public class GetAllAuthorQuery:IRequest<IEnumerable<Author>>
    {
     
     
    }
}
