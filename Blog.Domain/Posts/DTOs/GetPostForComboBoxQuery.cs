using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Blog.Domains.Posts.DTOs
{
    public class GetPostForComboBoxQuery:IRequest<IEnumerable<PostForComboboxDTO>>
    {
    }
}
