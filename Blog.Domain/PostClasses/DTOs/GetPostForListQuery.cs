using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses.DTOs;
using MediatR;

namespace Blog.Domain.PostClasses.DTOs
{
   public class GetPostForListQuery:IRequest<IEnumerable<PostListDTO>>
    {
    }
}
