using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Subjects.DTOs
{
    public class RemoveSubjectCommand : IRequest<ResultStatus>
    {
        public RemoveSubjectCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
