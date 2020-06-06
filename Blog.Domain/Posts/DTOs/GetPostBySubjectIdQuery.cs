﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Posts.DTOs
{
    public class GetPostBySubjectIdQuery : IRequest<IEnumerable<Post>>
    {
        public GetPostBySubjectIdQuery(long subjectId)
        {
            this.SubjectId = subjectId;
        }
        public long SubjectId { get; set; }



    }
}
