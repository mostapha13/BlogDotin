using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.PostClasses.DTOs;
using MediatR;

namespace Blog.Domain.PostClasses.DTOs
{
    public class GetPostForComboBoxQuery:IRequest<IEnumerable<PostForComboboxDTO>>
    {
    }
}
