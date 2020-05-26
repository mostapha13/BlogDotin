using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Enum;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.Queries;
using Blog.Service.SubjectClasses.Commands;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.SubjectClasses
{
    public class RemoveSubjectHandler : IRequestHandler<RemoveSubjectCommand, ResultStatus>
    {
        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;

        public RemoveSubjectHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
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
