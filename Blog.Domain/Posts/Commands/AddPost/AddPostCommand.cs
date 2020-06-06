using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Posts.Commands.AddPost
{
    public class AddPostCommand : IRequest<ResultStatus>
    {

        #region Propertise

        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string SubjectId { get; set; }
        public string Text { get; set; }

        #endregion
    }
}