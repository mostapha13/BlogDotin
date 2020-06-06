using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domains.Enums;
using Blog.Domains.Subjects.Commands.AddSubject;
using Blog.Domains.Subjects.Commands.RemoveSubject;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries.GetAllSubject;
using Blog.Domains.Subjects.Queries.GetAllSubjectPost;
using Blog.Domains.Subjects.Queries.GetSubjectForComboBox;
using Blog.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Controllers
{
   
    [CustomAction]
    public class SubjectController : BaseController
    {
        #region Constructor
    
        private readonly IMediator _mediator;
        public SubjectController(IMediator mediator)
        {
           
            _mediator = mediator;
        }
        #endregion

        #region GetAllSubject
        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject()
        {
            var query = new GetAllSubjectQuery();
            var result = await _mediator.Send(query);

            return result != null ? Success(result) : Error(new { info = "خطایی رخ داده است" });
        }
        #endregion

        #region AddSubject
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectDTO subjectDto)
        {
          
            if (!ModelState.IsValid)
            {
                Log.ForContext("Message", "AddSubject")
                    .ForContext("Error", "ModelStateNotValid")
                    .Error($"Error: ** AddSubject");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }

            var result = await _mediator.Send(new AddSubjectCommand()
            {
                Title = subjectDto.Title
            });
            switch (result)
            {
                case ResultStatus.Success:
                    return Success();
                default:
                    return Error(new { info = "خطایی رخ داده است" });
            }

        }
        #endregion

        #region RemoveSubject
        [HttpGet("RemoveSubject/{id}")]
        public async Task<IActionResult> RemoveSubject(int id)
        {
            var query = new RemoveSubjectCommand(id);
            var result = await _mediator.Send(query);
            switch (result)
            {
                case ResultStatus.NotFound:
                    return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
                case ResultStatus.Error:
                    return Error(new { info = "خطایی رخ داده است" });
                case ResultStatus.Success:
                    return Success();
                default:
                    return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AllSubjectPost
        [HttpGet("AllSubjectPost/{id}")]
        public async Task<IActionResult> AllSubjectPost(long id)
        {
            var query=new GetAllSubjectPostQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Success(result) : Error(new { info = "خطایی رخ داده است" });
        }

        #endregion


        #region GetAuthorForComboBox

        [HttpGet("GetSubjectForComboBox")]
        public async Task<IActionResult> GetSubjectForComboBox()
        {
            var query=new GetSubjectForComboBoxQuery();
            var result = await _mediator.Send(query);

            return result != null ? new ObjectResult(result) : null;
        }

        #endregion
    }
}