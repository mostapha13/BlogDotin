using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Enums;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.Commands.RemoveSubject;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries;
using MediatR;
using Serilog;

namespace Blog.Services.Subjects.Handler.Commands.RemoveSubject
{
    public class RemoveSubjectCommandHandler : IRequestHandler<RemoveSubjectCommand, ResultStatus>
    {
        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;

        public RemoveSubjectCommandHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion

        #region Handle

        public async Task<ResultStatus> Handle(RemoveSubjectCommand request, CancellationToken cancellationToken)
        {

            string functionName = "RemoveSubject:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            var subject = await _read.GetSubjectById(request.Id);
            if (subject == null)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "SubjectNotFound")
                    .Error($"Error ** {functionName}");
                return ResultStatus.NotFound;
            }

            await _write.RemoveSubject(subject);
            await _write.Save();
            return ResultStatus.Success;

        } 
        #endregion
    }
}
