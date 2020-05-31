using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Enums;
using Blog.Domains.Subjects;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Services.Subjects.Handler
{
    public class AddSubjectHandler : IRequestHandler<SubjectDTO, ResultStatus>
    {

        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;
       
        public AddSubjectHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
           
        }
        #endregion

        #region Handle

        public async Task<ResultStatus> Handle(SubjectDTO request, CancellationToken cancellationToken)
        {
          

            Subject subject = new Subject()
            {
                Title = request.Title
            };
            await _write.AddSubject(subject);
            await _write.Save();
            return ResultStatus.Success;


        } 
        #endregion
    }
}
