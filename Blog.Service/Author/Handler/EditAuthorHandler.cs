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
    public class EditAuthorHandler : IRequestHandler<AuthorForEditDTO, ResultStatus>
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
      


        public EditAuthorHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
       
        }
        #endregion


        #region Handle


        public async Task<ResultStatus> Handle(AuthorForEditDTO request, CancellationToken cancellationToken)
        {
            string functionName = "EditAuthor:Post" + JsonConvert.SerializeObject(request);



            Domain.AuthorClasses.Author author = new Domain.AuthorClasses.Author()
            {
                Id = request.Id,
                CreateDate = request.CreateDate,
                Email = request.Email.Trim().ToLower(),
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                IsDelete = request.IsDelete,
                UserName = request.UserName,

            };

           
                _write.UpdateAuthor(author);
                await _write.Save();
                return ResultStatus.Success;
     


        } 
        #endregion
    }
}
