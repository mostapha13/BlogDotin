using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Commands.EditAuthor;
using Blog.Domains.Authors.DTOs;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Enums;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Services.Authors.Handler.Commands.EditAuthor
{
    public class EditAuthorHandler : IRequestHandler<EditAuthorCommand, ResultStatus>
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


        public async Task<ResultStatus> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
        {
            

            Author author = new Author()
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
