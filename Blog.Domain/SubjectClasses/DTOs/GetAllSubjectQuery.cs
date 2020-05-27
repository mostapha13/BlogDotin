using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses;
using MediatR;

namespace Blog.Domain.SubjectClasses.DTOs
{
  public class GetAllSubjectQuery:IRequest<IEnumerable<Subject>>
    {
    }
}
