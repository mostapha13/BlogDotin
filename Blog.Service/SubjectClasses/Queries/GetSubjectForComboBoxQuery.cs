using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses.DTOs;
using MediatR;

namespace Blog.Service.SubjectClasses.Queries
{
  public  class GetSubjectForComboBoxQuery:IRequest<List<SubjectForComboboxDTO>>
    {
    }
}
