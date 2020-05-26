using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Enum;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.DTOs;
using Blog.Domain.SubjectClasses.Queries;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Handler.SubjectClasses
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
            string functionName = "AddSubject:Post:" + JsonConvert.SerializeObject(request);


            Domain.SubjectClasses.Subject subject = new Domain.SubjectClasses.Subject()
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
