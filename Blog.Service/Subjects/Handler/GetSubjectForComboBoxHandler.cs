using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Blog.Services.Subjects.Handler
{
    public class GetSubjectForComboBoxHandler:IRequestHandler<GetSubjectForComboBoxQuery,List<SubjectForComboboxDTO>>
    {

        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;
       
        public GetSubjectForComboBoxHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
            
        }
        #endregion

        #region Handle

        public async Task<List<SubjectForComboboxDTO>> Handle(GetSubjectForComboBoxQuery request, CancellationToken cancellationToken)
        {

            string functionName = "GetSubjectForComboBox:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            var subjectListCombo = await _read.GetSubjectForComboBox();

            List<SubjectForComboboxDTO> subjectList = new List<SubjectForComboboxDTO>();

            foreach (var subject in subjectListCombo)
            {
                subjectList.Add(new SubjectForComboboxDTO()
                {
                    Id = subject.Id,
                    Title = subject.Title
                });

            }

            return subjectList;
        } 
        #endregion
    }
}
