using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Posts.DTOs
{
    public class GetPostBySubjectIdQuery : IRequest<IEnumerable<Post>>
    {
        public long SubjectId { get; set; }
        public GetPostBySubjectIdQuery(long subjectId)
        {
            this.SubjectId = subjectId;
        }


    }
}
