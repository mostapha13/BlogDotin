using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Service.SubjectClasses.Commands
{
    public class RemoveSubjectCommand : IRequest<ResultStatus>
    {
        public int Id { get; set; }

        public RemoveSubjectCommand(int id)
        {
            Id = id;
        }
    }
}
