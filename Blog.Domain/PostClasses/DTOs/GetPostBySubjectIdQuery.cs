﻿using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.PostClasses;
using MediatR;

namespace Blog.Domain.PostClasses.DTOs
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