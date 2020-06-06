using Blog.Domains.Enums;
using MediatR;
namespace Blog.Domains.Comments.Commands.AddComment
{
    public class AddCommentCommand:IRequest<ResultStatus>
    {

        #region Propertise

        public string PostId { get; set; }
        public string Text { get; set; }

        #endregion

    }
}