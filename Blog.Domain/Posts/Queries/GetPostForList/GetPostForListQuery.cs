using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Posts.DTOs;
using MediatR;

namespace Blog.Domains.Posts.Queries.GetPostForList
{
   public class GetPostForListQuery:IRequest<IEnumerable<PostListDTO>>
    {
    }
}
