using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Authors.DTOs;
using MediatR;

namespace Blog.Domains.Authors.Queries.GetAuthorForComboBox
{
   public class GetAuthorForComboBoxQuery:IRequest<List<AuthorForComboboxDTO>>
    {
    }
}
