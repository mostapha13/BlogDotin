using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.DTOs;
using Blog.Domain.SubjectClasses.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Controllers
{
    
    public class SubjectController : BaseController
    {
        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;

        public SubjectController(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
        } 
        #endregion

        #region GetAllSubject
        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject()
        {
            string functionName = "GetAllSubject:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            try
            {
                return Success(await _read.GetAllSubject());
            }
            catch (Exception e)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", e.Message)
                    .Error($"Error:{e.Message} ** {functionName}");
                return Error(new{info= "خطایی رخ داده است" });
            }
        }
        #endregion

        #region AddSubject
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] Domain.SubjectClasses.DTOs.SubjectDTO subjectDto)
        {
            string functionName = "AddSubject:Post:"+JsonConvert.SerializeObject(subjectDto);
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);
            if (!ModelState.IsValid)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "ModelStateNotValid")
                    .Error($"Error: ** {functionName}");
                return Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }

           
            try
            {


                Domain.SubjectClasses.Subject subject=new Domain.SubjectClasses.Subject()
                {
                    Title = subjectDto.Title
                };
                await _write.AddSubject(subject);
                await _write.Save();
                return Success();
            }
            catch (Exception e)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", e.Message)
                    .Error($"Error:{e.Message} ** {functionName}");
                return Error(new{info= "خطایی رخ داده است" });
            }
        }
        #endregion

        #region RemoveSubject
        [HttpGet("RemoveSubject/{id}")]
        public async Task<IActionResult> RemoveSubject(int id)
        {
            string functionName = "RemoveSubject:Get:" + id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            var subject =await _read.GetSubjectById(id);
            if (subject == null)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "SubjectNotFound")
                    .Error($"Error ** {functionName}");
                return Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                _write.RemoveSubject(subject);
               await _write.Save();
               return Success();

            }
            catch (Exception e)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", e.Message)
                    .Error($"Error:{e.Message} ** {functionName}");
                return Error(new{info= "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AllSubjectPost
        [HttpGet("AllSubjectPost/{id}")]
        public async Task<IActionResult> AllSubjectPost(long id)
        {
            string functionName = "AllSubjectPost:Get:" + id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            try
            {
                return Success(await _read.GetAllSubjectPost(id));
            }
            catch (Exception e)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", e.Message)
                    .Error($"Error:{e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


        #region GetAuthorForComboBox

        [HttpGet("GetSubjectForComboBox")]
        public async Task<IActionResult> GetSubjectForComboBox()
        {
            string functionName = "GetSubjectForComboBox:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            var subjectListCombo=await _read.GetSubjectForComboBox();

            List<SubjectForComboboxDTO> subjectList=new List<SubjectForComboboxDTO>();

            foreach (var subject in subjectListCombo)
            {
                subjectList.Add(new SubjectForComboboxDTO()
                {
                    Id = subject.Id,
                    Title = subject.Title
                });

            }

            return new ObjectResult(subjectList);
        }

        #endregion
    }
}