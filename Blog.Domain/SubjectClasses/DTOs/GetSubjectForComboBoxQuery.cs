using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses.DTOs;
using MediatR;

namespace Blog.Domain.SubjectClasses.DTOs
{
  public  class GetSubjectForComboBoxQuery:IRequest<List<SubjectForComboboxDTO>>
    {
    }
}
