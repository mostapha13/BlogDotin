using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.PostClasses.DTOs;
using MediatR;

namespace Blog.Service.PostClasses.Queries
{
    public class GetPostForComboBoxQuery:IRequest<IEnumerable<PostForComboboxDTO>>
    {
    }
}
