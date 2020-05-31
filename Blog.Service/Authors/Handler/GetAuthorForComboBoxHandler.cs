using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.DTOs;
using Blog.Domains.Authors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Blog.Services.Authors.Handler
{
    public class GetAuthorForComboBoxHandler:IRequestHandler<GetAuthorForComboBoxQuery,List<AuthorForComboboxDTO>>
    {

        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
        


        public GetAuthorForComboBoxHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
            
        }
        #endregion

        #region Handle

        public async Task<List<AuthorForComboboxDTO>> Handle(GetAuthorForComboBoxQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAuthorForComboBox:Get";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

            var listAuthor = await _read.GetAllAuthorForCombobox();

            List<AuthorForComboboxDTO> listAuthorCombo = new List<AuthorForComboboxDTO>();
            foreach (var author in listAuthor)
            {
                listAuthorCombo.Add(new AuthorForComboboxDTO()
                {
                    Id = author.Id,
                    FullName = author.FirstName + ' ' + author.LastName
                });
            }

            return listAuthorCombo;

        }

        #endregion
    }
}
