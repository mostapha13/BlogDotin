using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Authors.Commands.AddAuthor
{
    public class AddAuthorCommand:IRequest<ResultStatus>
    {
        #region Propertise

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        #endregion
    }
}