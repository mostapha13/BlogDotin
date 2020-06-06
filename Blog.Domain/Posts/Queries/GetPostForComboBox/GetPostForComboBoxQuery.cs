using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domains.Posts.DTOs;
using MediatR;

namespace Blog.Domains.Posts.Queries.GetPostForComboBox
{
    public class GetPostForComboBoxQuery:IRequest<IEnumerable<PostForComboboxDTO>>
    {
    }
}
