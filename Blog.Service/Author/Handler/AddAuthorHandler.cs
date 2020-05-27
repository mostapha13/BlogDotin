using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.DTOs;
using Blog.Domain.AuthorClasses.Queries;
using Blog.Domain.Enum;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Service.Author.Handler
{
    public class AddAuthorHandler : IRequestHandler<AuthorDTO, ResultStatus>
    {

        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;



        public AddAuthorHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;

        }
        #endregion


        #region Handle

        public async Task<ResultStatus> Handle(AuthorDTO request, CancellationToken cancellationToken)
        {
            string functionName = "AddAuthor:Post:" + JsonConvert.SerializeObject(request);

            if (await _read.IsEmailExist(request.Email.Trim().ToLower()))
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "EmailIsExist").Error($"Error: ** {functionName}");
                return ResultStatus.EmailExist;
            }

            if (await _read.IsUserNameExist(request.UserName.Trim().ToLower()))
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "UserNameIsExist")
                    .Error($"Error: ** {functionName}");
                return ResultStatus.UserNameExist;
            }
            Domain.AuthorClasses.Author auth = new Domain.AuthorClasses.Author()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName.Trim().ToLower(),
                Email = request.Email.Trim().ToLower(),


            };
            await _write.AddAuthor(auth);
            await _write.Save();
            return ResultStatus.Success;

        }


        #endregion


    }
}
