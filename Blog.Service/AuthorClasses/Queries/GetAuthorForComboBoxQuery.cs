using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.AuthorClasses.DTOs;
using MediatR;

namespace Blog.Service.AuthorClasses.Queries
{
   public class GetAuthorForComboBoxQuery:IRequest<List<AuthorForComboboxDTO>>
    {
    }
}
