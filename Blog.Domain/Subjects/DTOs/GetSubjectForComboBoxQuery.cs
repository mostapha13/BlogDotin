using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Subjects.DTOs
{
  public  class GetSubjectForComboBoxQuery:IRequest<List<SubjectForComboboxDTO>>
    {
    }
}
