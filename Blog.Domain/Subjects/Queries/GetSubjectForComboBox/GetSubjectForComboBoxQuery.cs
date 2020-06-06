using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Subjects.DTOs;
using MediatR;

namespace Blog.Domains.Subjects.Queries.GetSubjectForComboBox
{
  public  class GetSubjectForComboBoxQuery:IRequest<List<SubjectForComboboxDTO>>
    {
    }
}
